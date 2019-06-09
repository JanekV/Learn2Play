import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { IFolder } from "interfaces/IFolder";
import { FoldersService } from "services/folders-service";

export var log = LogManager.getLogger('Folders.Index');

@autoinject
export class Index{

  private folders: IFolder[] = [];

  constructor(
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
    log.debug('attached');
    this.foldersService.fetchAll(undefined).then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.folders = jsonData;
      }
    );

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
