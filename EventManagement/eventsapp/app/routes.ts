import { Routes } from '@angular/router';
import{
EventsListComponent,
EventDetailsComponent,
CreateEventComponent,
EventRouteActivator,
EventRouteDeactivator,
EventListResolver,
CreateSessionComponent
} from './events/index'
import {  } from './events/events-list.component';
import {  } from "./events/event-details.component";
import { Error404Component } from "./errors/404.component";


export const routes: Routes = [
    { path: 'events/new', component: CreateEventComponent, canDeactivate: [EventRouteDeactivator] },
    {
        path: 'events', component: EventsListComponent, resolve: {
            events: EventListResolver
        }
    },
    { path: 'events/:id', component: EventDetailsComponent, canActivate: [EventRouteActivator] },
    { path: 'events/session/new', component: CreateSessionComponent },
    { path: '404', component: Error404Component },
    { path: '', redirectTo: '/events', pathMatch: 'full' },
    { path: 'Home/Index', redirectTo: '/events', pathMatch: 'full' },
    { path: 'user', loadChildren: 'app/user/user.module#UserModule' }
];
