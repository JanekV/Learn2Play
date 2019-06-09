import { PLATFORM, LogManager, autoinject } from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter{

  public router: Router;

  constructor(
    private appConfig: AppConfig
  ){
    log.debug('constructor');
  }

  configureRouter(config: RouterConfiguration, router: Router): void{
    log.debug('configureRouter');

    this.router = router;
    config.title = "Learn2Play App - Aurelia";
    config.map([
      {
        route: ['', 'home'],
        name: 'home',
        moduleId: PLATFORM.moduleName('home'),
        nav: true, 
        title: 'Home'
      },

      //Identity login routes
      {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
      {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
      {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},

      // //Notes controller routes
      // {route: ['notes' ,'notes/index'], name: 'notes' + 'Index', moduleId: PLATFORM.moduleName('notes/index'), nav: true, title: 'Notes'},
      // {route: 'notes/create', name: 'notes' + 'Create', moduleId: PLATFORM.moduleName('notes/create'), nav: false, title: 'Notes Create'},
      // {route: 'notes/edit/:id', name: 'notes' + 'Edit', moduleId: PLATFORM.moduleName('notes/edit'), nav: false, title: 'Notes Edit'},
      // {route: 'notes/details/:id', name: 'notes' + 'Details', moduleId: PLATFORM.moduleName('notes/details'), nav: false, title: 'Notes Details'},
      // {route: 'notes/delete/:id', name: 'notes' + 'Delete', moduleId: PLATFORM.moduleName('notes/delete'), nav: false, title: 'Notes Delete'},

      // //Chords controller routes
      // {route: ['chords' ,'chords/index'], name: 'chords' + 'Index', moduleId: PLATFORM.moduleName('chords/index'), nav: true, title: 'Chords'},
      // {route: 'chords/create', name: 'chords' + 'Create', moduleId: PLATFORM.moduleName('chords/create'), nav: false, title: 'Chords Create'},
      // {route: 'chords/edit/:id', name: 'chords' + 'Edit', moduleId: PLATFORM.moduleName('chords/edit'), nav: false, title: 'Chords Edit'},
      // {route: 'chords/details/:id', name: 'chords' + 'Details', moduleId: PLATFORM.moduleName('chords/details'), nav: false, title: 'Chords Details'},
      // {route: 'chords/delete/:id', name: 'chords' + 'Delete', moduleId: PLATFORM.moduleName('chords/delete'), nav: false, title: 'Chords Delete'},

      // //ChordNotes controller routes
      // {route: ['chordnotes' ,'chordnotes/index'], name: 'chordnotes' + 'Index', moduleId: PLATFORM.moduleName('chordnotes/index'), nav: true, title: 'ChordNotes'},
      // {route: 'chordnotes/create', name: 'chordnotes' + 'Create', moduleId: PLATFORM.moduleName('chordnotes/create'), nav: false, title: 'ChordNotes Create'},
      // {route: 'chordnotes/edit/:id', name: 'chordnotes' + 'Edit', moduleId: PLATFORM.moduleName('chordnotes/edit'), nav: false, title: 'ChordNotes Edit'},
      // {route: 'chordnotes/details/:id', name: 'chordnotes' + 'Details', moduleId: PLATFORM.moduleName('chordnotes/details'), nav: false, title: 'ChordNotes Details'},
      // {route: 'chordnotes/delete/:id', name: 'chordnotes' + 'Delete', moduleId: PLATFORM.moduleName('chordnotes/delete'), nav: false, title: 'ChordNotes Delete'},

      //Folders controller routes
      {route: ['folders' ,'folders/index'], name: 'folders' + 'Index', moduleId: PLATFORM.moduleName('folders/index'), nav: true, title: 'Folders'},
      {route: 'folders/create', name: 'folders' + 'Create', moduleId: PLATFORM.moduleName('folders/create'), nav: false, title: 'Folder Create'},
      {route: 'folders/edit/:id', name: 'folders' + 'Edit', moduleId: PLATFORM.moduleName('folders/edit'), nav: false, title: 'Folder Edit'},
      {route: 'folders/details/:id', name: 'folders' + 'Details', moduleId: PLATFORM.moduleName('folders/details'), nav: false, title: 'Folder Details'},
      {route: 'folders/delete/:id', name: 'folders' + 'Delete', moduleId: PLATFORM.moduleName('folders/delete'), nav: false, title: 'Folder Delete'},

      //Songs controller routes
      {route: ['songs' ,'songs/index'], name: 'songs' + 'Index', moduleId: PLATFORM.moduleName('songs/index'), nav: true, title: 'Songs'},
      //SongWithEverything controller route
      {route: 'songs/details/:id', name: 'songs' + 'Details', moduleId: PLATFORM.moduleName('songs/details'), nav: false, title: 'Song Details'},

      
    ]);
  }
}
