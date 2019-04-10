import { PLATFORM, LogManager } from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";

export var log = LogManager.getLogger('MainRouter');

export class MainRouter{

  public router: Router;
  constructor(){
    log.debug('constructor');
  }

  configureRouter(config: RouterConfiguration, router: Router): void{
    log.debug('configureRouter');

    this.router = router;
    config.title = "Learn2Play App - Aurelia";
    config.map([
      {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'}
    ]);
  }
}
