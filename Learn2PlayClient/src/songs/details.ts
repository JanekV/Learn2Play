import { ISongWithEverything } from './../interfaces/ISongWithEverything';
import { SongWithEverythingService } from 'services/song-with-everything-service';
import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";

export var log = LogManager.getLogger('Songs.Details');

@autoinject
export class Details{

  private song: ISongWithEverything | null = null;

  constructor(
    private router: Router,
    private songWithEverythingService: SongWithEverythingService
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
    this.songWithEverythingService.fetch(params.id).then(
      song => {
        log.debug('song', song);
        this.song = song;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
