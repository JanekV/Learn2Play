import { FoldersService } from 'services/folders-service';
import { ISongWithEverything } from './../interfaces/ISongWithEverything';
import { SongsService } from 'services/songs-service';
import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { IFolder } from 'interfaces/IFolder';

export var log = LogManager.getLogger('Songs.Details');

@autoinject
export class Details{

  private song: ISongWithEverything | null = null;
  @bindable private folderIds: number[] = [];
  private folders: IFolder[] = [];

  constructor(
    private router: Router,
    private songService: SongsService,
    private folderService: FoldersService
  ){
    log.debug('constructor');
  }

  // =============== View LifeCycle events ================
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object,overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attatched');
  }

  detached() {
    log.debug('detatched');
  }

  unbind() {
    log.debug('unbind');
  }

  // =============== Router Events =======================
  canActivate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }
  activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.songService.fetchSWE(params.id).then(
      song => {
        log.debug('song', song);
        log.debug('song folders', song.folders);
        this.song = song;
      }
    );
    this.folderService.fetchAll(undefined).then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.folders = jsonData;
      }
    )
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
  // =============== Stuffffff =======================
  putInFolders():void {
    log.debug('putInFolder called' + this.folderIds)
    this.songService.putSongInFolder(this.song.id, this.folderIds).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("songsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    )

  }
}
