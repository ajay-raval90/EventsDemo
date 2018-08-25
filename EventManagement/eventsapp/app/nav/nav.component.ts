import { Component } from '@angular/core';
import { AuthService } from "../user/auth.service";
import { ISession } from "../events/shared/event.model";
import { EventService } from "../events/shared/index";
@Component({
    selector: 'nav-bar',
    templateUrl: 'app/nav/nav.component.html',
    styles: [
        `.nav.navbar-nav {font-size:15px;}
        #seacchForm {margin-right: 100px;}
        @media(max-width:1200px){
            #searchForm {
                display:none;
            }
        }
        li > a.active{ color:#F97924 }
        `

    ]
})
export class NavBarCompnent {
    searchTerm: string = "";
    foundSessions: ISession[];
    constructor(private auth: AuthService,private eventService:EventService) {
    }
    searchSessions(searchTerm) {
        this.eventService.searchSessions(searchTerm).subscribe(sessions=>{
            this.foundSessions = sessions;
        });

    }
}