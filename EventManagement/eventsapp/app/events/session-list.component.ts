import { Component, Input, OnChanges, Inject } from '@angular/core'
import { ISession, VoterService } from "./shared/index";
import { LODASH_TOKEN } from "../common/loadsh-service";
import { AuthService } from '../user/auth.service';

@Component({
    selector: 'session-list',
    templateUrl: 'app/events/session-list.component.html'
})
export class SessionListComponent implements OnChanges {
    @Input() sessions: ISession[];
    @Input() filterBy: string;
    @Input() sortBy: string;
    visibleSessions: ISession[];
    constructor( @Inject(LODASH_TOKEN) private _: any,private auth:AuthService,private voterService:VoterService) {

    }

    ngOnChanges(changes): void {
        if (this.sessions) {
            this.filterSessions(this.filterBy);
            this.sortSessions(this.sortBy);
        }
    }
    toggleVote(session:ISession)
    {
        if(this.userHasVoted(session))
        {
            this.voterService.deleteVoter(session,this.auth.currentUser.userName);
        }
        else
        {
            this.voterService.addVoter(session,this.auth.currentUser.userName);
        }
        if(this.sortBy ==="votes")
        {
            this.sortSessions(this.sortBy);
        }
    }
    userHasVoted(session:ISession)
    {
        return this.voterService.userHasVoted(session,this.auth.currentUser.userName);
    }
    filterSessions(filter: string) {
        if (filter === 'all') {
            this.visibleSessions = this.sessions.slice(0);
        }
        else {
            this.visibleSessions = this.sessions.filter(s => {
                return s.level.toLowerCase() === filter;
            });
        }
    }
    sortSessions(sort: string) {
        if (sort.toLocaleLowerCase() === 'name') {
            this.visibleSessions = this._.sortBy(this.visibleSessions, sort.toLocaleLowerCase())
        }
        else if (sort.toLocaleLowerCase() === 'votes') {
            this.visibleSessions = this.visibleSessions.sort(this.sortByVoteDesc)
        }
    }
    private sortByVoteDesc (s1:ISession,s2:ISession) {
        return (s2.voters.length - s1.voters.length);
    }
    
}
