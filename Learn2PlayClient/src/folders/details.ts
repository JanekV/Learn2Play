import { FoldersService } from 'services/folders-service';
import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { IFolder } from "interfaces/IFolder";

export var log = LogManager.getLogger('Folders.Details');

@autoinject
export class Details{

  private folder: IFolder | null = null;

  constructor(
    private router: Router,
    private foldersService: FoldersService
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
    this.foldersService.fetch(params.id).then(
      folder => {
        log.debug('folder', folder);
        this.folder = folder;
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