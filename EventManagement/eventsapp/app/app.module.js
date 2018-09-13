"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var index_1 = require("./events/index");
var nav_component_1 = require("./nav/nav.component");
var event_service_1 = require("./events/shared/event-service");
var index_2 = require("./common/index");
var router_1 = require("@angular/router");
var routes_1 = require("./routes");
var _404_component_1 = require("./errors/404.component");
var auth_service_1 = require("./user/auth.service");
var _1 = require("@angular/forms/");
var http_1 = require("@angular/http");
var index_3 = require("./events/shared/index");
var auth_activator_1 = require("./user/auth.activator");
var location_validator_directive_1 = require("./events/location-validator.directive");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule,
                router_1.RouterModule.forRoot(routes_1.routes),
                _1.FormsModule,
                http_1.HttpModule,
                _1.ReactiveFormsModule,
            ],
            declarations: [
                index_1.EventsAppComponent,
                index_1.EventsListComponent,
                index_1.EventThumbnailComponent,
                nav_component_1.NavBarCompnent,
                index_1.EventDetailsComponent,
                _404_component_1.Error404Component,
                index_1.CreateEventComponent,
                index_1.CreateSessionComponent,
                index_1.SessionListComponent,
                index_2.CollapsibleWellComponent,
                index_2.SimpleModalComponent,
                index_2.ModalTriggerDirective,
                index_1.UpvoteComponet,
                index_3.DurationPipe,
                location_validator_directive_1.LocationValidator
            ],
            providers: [event_service_1.EventService,
                index_1.EventRouteActivator,
                index_1.EventRouteDeactivator,
                index_1.EventListResolver,
                auth_service_1.AuthService,
                index_3.VoterService,
                { provide: index_2.LODASH_TOKEN, useValue: _ },
                { provide: index_2.TOASTR_TOKEN, useValue: toastr },
                { provide: index_2.JQ_TOKEN, useValue: jQuery },
                auth_activator_1.AuthActivator
            ],
            bootstrap: [index_1.EventsAppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map