import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { ISong } from "interfaces/ISong";
import { SongsService } from "services/songs-service";

export var log = LogManager.getLogger('Songs.Index');

@autoinject
export class Index{

  private songs: ISong[] = [];

  @bindable private search: string = '';

  constructor(
    private songsService: SongsService
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
    log.debug('attached');
    this.loadData();
  }

  detached() {
    log.debug('detatched');
  }

  unbind() {
    log.debug('unbind');
  }
  loadData(){
    this.songsService.fetchAll('?search=' + this.search).then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.songs = jsonData;
      }
    );
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

  // =============== Search =======================
  searchClicked() {
    log.debug('searchClicked', this.search);
    this.loadData();
  }

  searchResetClicked() {
    log.debug('searchResetClicked');
    this.search = '';
    this.loadData();
  }


}
