namespace IndiProject {

    angular.module('IndiProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: IndiProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: IndiProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: IndiProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: IndiProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: IndiProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: IndiProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('albums', {
                url: '/albums',
                templateUrl: '/ngApp/views/albums.html',
                controller: IndiProject.Controllers.AlbumsController,
                controllerAs: 'controller'
            })

            .state('artists', {
                url: '/artists',
                templateUrl: '/ngApp/views/artists.html',
                controller: IndiProject.Controllers.HomeController,
                controllerAs: 'controller'
            })

            .state('addArtist', {
                url: '/addArtist',
                templateUrl: '/ngApp/views/addArtist.html',
                controller: IndiProject.Controllers.addArtistController,
                controllerAs: 'controller'
            })

            .state('addAlbum', {
                url: '/addAlbum/:id',
                templateUrl: '/ngApp/views/addAlbum.html',
                controller: IndiProject.Controllers.addAlbumToArtistController,
                controllerAs: 'controller'
            })

            .state('delete', {
                url: '/deleteAlbum/:id',
                templateUrl: '/ngApp/views/delete.html',
                controller: IndiProject.Controllers.deleteAlbumController,
                controllerAs: 'controller'
            })

            .state('deleteArtist', {
                url: '/deleteArtist/:id',
                templateUrl: '/ngApp/views/deleteArtist.html',
                controller: IndiProject.Controllers.deleteArtistController,
                controllerAs: 'controller'
            })

            .state('editArtist', {
                url: '/editArtist/:id',
                templateUrl: '/ngApp/views/editArtist.html',
                controller: IndiProject.Controllers.editArtistController,
                controllerAs: 'controller'
            })

            .state('editAlbum', {
                url: '/editAlbum/:id',
                templateUrl: '/ngApp/views/editAlbum.html',
                controller: IndiProject.Controllers.editAlbumController,
                controllerAs: 'controller'
            })

            .state('tracks', {
                url: '/tracks/:id',
                templateUrl: '/ngApp/views/tracks.html',
                controller: IndiProject.Controllers.TracksController,
                controllerAs: 'controller'
            })

            .state('editTrack', {
                url: '/editTrack/:id',
                templateUrl: '/ngApp/views/editTrack.html',
                controller: IndiProject.Controllers.editTrackController,
                controllerAs: 'controller'
            })

            .state('deleteTrack', {
                url: '/deleteTrack/:id',
                templateUrl: '/ngApp/views/deleteTrack.html',
                controller: IndiProject.Controllers.deleteTrackController,
                controllerAs: 'controller'
            })

            .state('addTrack', {
                url: '/addTrack/:id',
                templateUrl: '/ngApp/views/addTrack.html',
                controller: IndiProject.Controllers.addTrackController,
                controllerAs: 'controller'
            })

            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('IndiProject').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('IndiProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
