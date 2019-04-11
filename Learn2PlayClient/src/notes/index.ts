import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { INote } from "interfaces/INote";
import { NotesService } from "services/notes-service";

export var log = LogManager.getLogger('Notes.Index');

@autoinject
export class Index{

  private notes: INote[] = [];

  constructor(
    private notesService: NotesService
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
    this.notesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.notes = jsonData;
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
