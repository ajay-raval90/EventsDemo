import { Injectable } from '@angular/core';
import { CanDeactivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { EventService } from './shared/event-service';
import { CreateEventComponent } from './create-event.component';
@Injectable()
export class EventRouteDeactivator implements CanDeactivate<CreateEventComponent>
{
    constructor(private eventService: EventService, private router : Router) {
    
    }
    canDeactivate(component:CreateEventComponent){
        if(component.isDirty)
        {
            return confirm("There are unsaved changes? Are you sure want to leave this page?")
        }
        return true;
    }
}