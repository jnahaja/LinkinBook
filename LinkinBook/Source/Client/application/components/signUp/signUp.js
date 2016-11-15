(function () {
    'use strict';

    angular
        .module('linkinBook')
        .directive('signUp', directive);

    function directive() {
        // Usage:
        //     <sign-up></sign-up>
        // Creates:
        // 
        var directive = {
            restrict: 'E',
            templateUrl: 'application/components/signUp/signUp.html'
        };
        return directive;
    }

})();