import { NotesService } from 'services/notes-service';
import { LogManager, View, autoinject } from "aurelia-framework";
import { RouteConfig, NavigationInstruction, Router } from "aurelia-router";
import { INote } from "interfaces/INote";

export var log = LogManager.getLogger('Notes.Details');

@autoinject
export class Details{

  private note: INote | null = null;

  constructor(
    private router: Router,
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
    this.notesService.fetch(params.id).then(
      note => {
        log.debug('note', note);
        this.note = note;
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
