
var gulp = require('gulp-help')(require('gulp'),
    gutil = require('gulp-util'),
    inject = require('gulp-inject'),
    clean = require('gulp-clean'),
    rename = require("gulp-rename"));

var del = require("del");

var bowerPath = './bower_components/**/*';
var distRoot = '../Source/Client';
var distExternal = distRoot + '/external';
var distApp = distRoot + '/application';

//EXTERNAL FOLDER CLEAN_COPY
gulp.task('client-clean-external', 'This task clean externals', function () {
    return gulp.src(distExternal + '/*', { read: false })
      .pipe(clean({ force: true }));
});

gulp.task('client-copy-external', 'This task copy externals', ['client-clean-external'], function () {
    return gulp.src(bowerPath).pipe(gulp.dest(distExternal));
});


gulp.task('client-build-external', 'This task build externals', ['client-copy-external'], function () {
    return gulp.src(bowerPath).pipe(gulp.dest(distExternal));
});

//INDEX build

//delete index file
gulp.task('client-clean-index',
    'delete the client index.html file.',
    [],
    function () {
        return del([distRoot + '/index.html'], { force: true });
    });

gulp.task('index-build', 'This task copy js - css files', ['client-build-external', 'client-clean-index'], function () {
    var target = gulp.src(distRoot + '/index.build.html');

    var sources = gulp.src(
        [
            distExternal + '/**/*.js',
            distExternal + '/**/*.css',
            distApp + '/**/*.js'
        ],
            { read: false }, { relative: true }
        );

    return target.pipe(inject(sources))
                 .pipe(gulp.dest(distRoot));
});



//rename index.buid to index
gulp.task('start-build-index', 'This task renames index-build', ['index-build'], function () {
    gulp.src(distRoot + '/index.build.html')
   .pipe(rename(function (path) {
       path.basename = "index";
       path.extname = ".html";
   }))
    .pipe(gulp.dest(distRoot));


});


