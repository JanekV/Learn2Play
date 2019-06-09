import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { ISong } from "interfaces/ISong";
import { SongsService } from "services/songs-service";

export var log = LogManager.getLogger('Songs.Create');

@autoinject
export class Create{

  private song: ISong;

  constructor(
    private router: Router,
    private songsService: SongsService
  ){
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('song', this.song);
    this.songsService.post(this.song).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("songsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
