import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
    EventsAppComponent,
    EventsListComponent,
    EventThumbnailComponent,
    EventDetailsComponent,
    CreateEventComponent,
    EventRouteActivator,
    EventRouteDeactivator,
    EventListResolver,
    CreateSessionComponent,
    SessionListComponent,
    UpvoteComponet
} from './events/index'


import { NavBarCompnent } from './nav/nav.component';
import { EventService } from './events/shared/event-service';
import {
    TOASTR_TOKEN,
    CollapsibleWellComponent,
    LODASH_TOKEN,
    IToastr,
    JQ_TOKEN,
    SimpleModalComponent,
    ModalTriggerDirective
} from './common/index';
import { RouterModule } from "@angular/router";
import { routes } from './routes';
import { Error404Component } from './errors/404.component';
import { AuthService } from "./user/auth.service";
import { ReactiveFormsModule, FormsModule } from "@angular/forms/";
import { DurationPipe, VoterService } from "./events/shared/index";
import { AuthActivator } from './user/auth.activator';
import { LocationValidator } from './events/location-validator.directive';



declare let _: any
declare let jQuery:Object
declare let toastr:IToastr
@NgModule({
    imports: [BrowserModule,
        RouterModule.forRoot(routes),
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [
        EventsAppComponent,
        EventsListComponent,
        EventThumbnailComponent,
        NavBarCompnent,
        EventDetailsComponent,
        Error404Component,
        CreateEventComponent,
        CreateSessionComponent,
        SessionListComponent,
        CollapsibleWellComponent,
        SimpleModalComponent,
        ModalTriggerDirective,
        UpvoteComponet,
        DurationPipe,
        LocationValidator
    ],
    providers: [EventService,
        EventRouteActivator,
        EventRouteDeactivator,
        EventListResolver,
        AuthService,
        VoterService,
        { provide: LODASH_TOKEN, useValue : _ },
        { provide: TOASTR_TOKEN, useValue : toastr },
        { provide: JQ_TOKEN, useValue : jQuery },
        AuthActivator
    ],
    bootstrap: [EventsAppComponent]
})
export class AppModule {

}