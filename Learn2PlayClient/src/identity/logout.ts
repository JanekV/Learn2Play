import { AppConfig } from 'app-config';
import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {INote} from "../interfaces/INote";
import {NotesService} from "../services/notes-service";
import {IChord} from "../interfaces/IChord";
import {ChordsService} from "../services/chords-service";
import {BaseService} from "../services/base-service";

export var log = LogManager.getLogger('Identity.Logout');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Logout {

  private notes: INote[] = [];
  private chords: IChord[] = [];

  constructor(
    private notesService: NotesService,
    private chordsService: ChordsService,
    private router: Router,
    private appConfig: AppConfig
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
    this.appConfig.jwt = null;
    this.router.navigateToRoute('home');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
