import { Component, EventEmitter, Output, Input } from '@angular/core'
@Component({
    selector: 'upvote',
    template: `
    <div class="voteingWidgetContainer pointable" (click)="onClick()">
        <div class="well votingWidget">
            <i [style.color]="iconColor"
            class="glyphicon glyphicon-heart"></i>
            
        <div>
        <div class="badge badge-invers votingCount">
            <div>{{count}}</div>
        </div>
    </div>
    `,
    styleUrls: [
        `app/events/upvote.component.css`
    ]
})
export class UpvoteComponet {
    @Output() vote = new EventEmitter();
    @Input() count: number;
    @Input() set voted(val) {
        this.iconColor = val ? 'red' : 'white'
    };
    iconColor: string;
    onClick() {
        this.vote.emit({});
    }
}
