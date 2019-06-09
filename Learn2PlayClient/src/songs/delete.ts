import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { ISong } from "interfaces/ISong";
import { SongsService } from "services/songs-service";

export var log = LogManager.getLogger('Songs.Delete');

@autoinject
export class Delete{

  private song: ISong;

  constructor(
    private router: Router,
    private songsService: SongsService
  ){
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.songsService.delete(this.song.id).then(response => {
      if (response.status == 204){
        this.router.navigateToRoute("songsIndex");
      } else {
        log.debug('response', response);
      }
    });
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
    log.debug('activate', params);
    this.songsService.fetch(params.id).then(
      song => {
        log.debug('song', song);
        this.song = song;
      }
    );

  }
  activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
