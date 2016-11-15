(function () {
    'use strict';

    angular
        .module('linkinBook')
        .directive('home', directive);

    function directive() {
        // Usage:
        //     <home></home>
        // Creates:
        // 
        var directive = {
            restrict: 'E',
            templateUrl: 'application/components/home/home.html'
        };
        return directive;
    }

})();