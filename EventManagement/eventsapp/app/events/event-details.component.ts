import { Component, OnInit } from "@angular/core";
import { EventService } from "./shared/event-service";
import { ActivatedRoute, Params } from '@angular/router';
import { IEvent, ISession } from "./shared/index";
@Component({
    selector: 'event-detail',
    templateUrl: 'app/events/event-details.component.html',
    styles: [
        `.container {padding-left:20px; padding-right:20px}
        .event-image {height:100px;}
        a {cursor:pointer}
        `
    ]
})
export class EventDetailsComponent implements OnInit {
    event: IEvent;
    addMode: boolean;
    filterBy: string = 'all';
    sortBy: string = 'name';
    constructor(private eventService: EventService, private route: ActivatedRoute) {

    }
    ngOnInit() {
        this.route.params.forEach((routeParams: Params) => {
            this.eventService.getEvent(+routeParams['id']).subscribe((event: IEvent) => {
                console.log(event)
                this.event = event;
                this.resetComponent();
            });    
            
        });
    }
    addSession() {
        this.addMode = true;
    }
    resetComponent()
    {
        this.addMode = false;
        this.filterBy="all";
        this.sortBy="name";
    }
    saveNewSession(session: ISession) {
        session.eventId = this.event.id;
        this.event.sessions.push(session);
        this.eventService.saveEvent(this.event).subscribe((res: IEvent) => {
            this.addMode = false;
            this.event = res;
        });
    }
    cancelAddSession() {
        this.addMode = false;
    }
}