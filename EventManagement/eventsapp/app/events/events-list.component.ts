import { Component,OnInit } from '@angular/core'
import {EventService} from './shared/event-service'
import { ActivatedRoute } from "@angular/router";
import { IEvent } from "./shared/index";

@Component({
    selector: 'events-list',
    template: `<div>
                <h1>Upcoming Angular Events</h1>
                <hr/>
                <div class="row" >
                    <div [routerLink]="['/events',event.id]" class="col-md-5" *ngFor="let event of events">
                        <event-thumbnail  [event]="event"></event-thumbnail>
                    </div>
                </div>
            </div>`,
})
export class EventsListComponent implements OnInit{
    events: IEvent[];
    constructor(private eventServcice:EventService,private route:ActivatedRoute) {
    }
    ngOnInit(){
            this.events = this.route.snapshot.data["events"];
    }
}