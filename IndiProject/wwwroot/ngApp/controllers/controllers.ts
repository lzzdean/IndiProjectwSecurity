namespace IndiProject.Controllers {

    export class HomeController {
        private ArtistResource;
        private AlbumResource;
        public Albums;
        public Artists;
        public getArtists() {
            this.Artists = this.ArtistResource.query();
        }
        public getAlbums() {
            this.Albums = this.AlbumResource.query();
        }
              
        

        constructor(private $resource: angular.resource.IResourceService) {
            this.ArtistResource = $resource('/api/artists/:id');
            this.AlbumResource = $resource('/api/albums/:id');
            this.getAlbums();
            this.getArtists();
        }

    }

    export class addArtistController {
        private ArtistResource;
        public artist;

        public addArtist() {
            return this.ArtistResource.save(this.artist)
                .$promise.then(() => { this.$state.go('home') }
                );
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.ArtistResource = $resource('/api/artists/:id');
        }
    }

    export class deleteArtistController {
        private ArtistResource;
        public artistId;

        public deleteArtist() {
            return this.ArtistResource.delete({
                id: this.artistId
            }).$promise.then(() => { this.$state.go('home') }
                );
        }
        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.ArtistResource = $resource('/api/artists/:id');
            this.artistId = $stateParams['id'];
        }

    }

    export class editArtistController {
        private ArtistResource;
        public artist;
        public artistId;

        public editArtist() {

            return this.ArtistResource.save({
                id: this.artistId
            }, this.artist).$promise.then(() => { this.$state.go('home') }
                );
        }

        public getArtist() {
            this.artist = this.ArtistResource.get({ id: this.artistId });
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.ArtistResource = $resource('/api/artists/:id');
            this.artistId = $stateParams['id'];
            this.getArtist();
        }
    }
    export class AlbumsController {
        private AlbumResource;
        public albums;
        public search;

        public fetch() { };

        public getAlbums() {
            this.albums = this.AlbumResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService, private $http: ng.IHttpService) {
            this.AlbumResource = $resource('/api/albums/:id');
            this.getAlbums();
        }
    }


    export class addAlbumToArtistController {
        private AlbumResource;
        public album;
        public artistId;


        public addAlbumToArtist() {
            this.album.artistId = this.artistId;
            return this.AlbumResource.save
                (this.album).$promise.then(() => { this.$state.go('home') }
                );
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.AlbumResource = $resource('/api/albums/:id');
            this.artistId = $stateParams['id'];
        }
    }

    //needs button
    export class deleteAlbumController {
        private AlbumResource;
        public albumId;

        public deleteAlbum() {
            return this.AlbumResource.delete({
                id: this.albumId
            }).$promise.then(() => { this.$state.go('home') }
                );
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.AlbumResource = $resource('/api/albums/:id');
            this.albumId = $stateParams['id'];
            this.deleteAlbum();
        }
    }
   
    export class editAlbumController {
        private AlbumResource;
        public albums;
        public album;
        public albumId;

        public editAlbum() {

            return this.AlbumResource.save({ id: this.albumId }, this.album).$promise.then(() => { this.$state.go('home') }
            );

        }
        public getAlbum() {
            this.album = this.AlbumResource.get({ id: this.albumId });
        }
        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.AlbumResource = $resource('/api/albums/:id');
            this.albumId = $stateParams['id'];
            this.getAlbum();
        }
    }

  
    export class TracksController {
        private AlbumResource;
        private TrackResource;
        public album;
        public albumId;

        public getAlbum() {
            this.album = this.AlbumResource.get({ id: this.albumId });
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService) {
            this.AlbumResource = $resource('/api/albums/:id');
            this.albumId = $stateParams['id'];
            this.getAlbum();
        }
    }

    export class addTrackController {
        private TrackResource;
        private AlbumResource; 
        public track;
        

        

        public addTrack() {
            this.track.albumId = this.$stateParams['id'];
            this.TrackResource.save(this.track).$promise.then(() =>
            { this.$state.go('home') });
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.TrackResource = $resource('/api/tracks/:id');
            this.AlbumResource = $resource('/api/albums/:id');
                        
        }
    }

         export class editTrackController {
            private TrackResource;
            public track;
            public trackId;

            public editTrack() {

                return this.TrackResource.save({ id: this.trackId }, this.track).$promise.then(() => { this.$state.go('albums') });
            }
            public getTrack() {
                this.track = this.TrackResource.get({ id: this.trackId });
            }
            constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
                this.TrackResource = $resource('/api/tracks/:id');
                this.trackId = $stateParams['id']
                this.getTrack();
            }
        }
        export class deleteTrackController {
        private TrackResource;
        public trackId;

        public deleteTrack() {
            return this.TrackResource.delete({
                id: this.trackId
            }).$promise.then(() => { this.$state.go('albums') }
                );
        }

        constructor(private $resource: angular.resource.IResourceService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.TrackResource = $resource('/api/tracks/:id');
            this.trackId = $stateParams['id'];
            this.deleteTrack();
        }
    }
   


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}

