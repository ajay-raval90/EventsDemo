import { Component, OnInit, EventEmitter, Output } from '@angular/core'
import { Validators, FormControl, FormGroup } from '@angular/forms'
import { ISession } from './shared/index'
import { Router } from "@angular/router";
import { restrictedWords } from "./index";
@Component({
    selector:'create-session',
    templateUrl: 'app/events/create-session.component.html',
    styles: [
        `em {float:right; color:#E05C65; padding-left:10px}
    .error input {background-color:#E3C3C5}
    .error ::-webkit-input-placeholder {color:#999}
    .error ::-moz-placeholder {color:#999}
    .error :-moz-placeholder {color:#999}
    .error :ms-input-placeholder {color:#999}
     `
    ]
})
export class CreateSessionComponent implements OnInit {
    router: Router
    constructor(_router: Router) {
        this.router = _router
    }
    newSessionForm: FormGroup;
    name: FormControl;
    presenter: FormControl;
    duration: FormControl;
    abstract: FormControl;
    level: FormControl;
    @Output() saveNewSession  = new EventEmitter();
    @Output() cancelAddSession  = new EventEmitter();
    ngOnInit(): void {
        this.name = new FormControl('', Validators.required);
        this.presenter = new FormControl('', Validators.required);
        this.duration = new FormControl('', Validators.required);
        this.level = new FormControl('', Validators.required);
        this.abstract = new FormControl('', [Validators.required, Validators.maxLength(400), restrictedWords(['foo','bar'])]);

        this.newSessionForm = new FormGroup({
            name: this.name,
            presenter: this.presenter,
            duration: this.duration,
            level: this.level,
            abstract: this.abstract,
        });
    }
    levels: any = [
        { text: "Beginner", value: "Beginner" },
        { text: "Intermediate", value: "Intermediate" },
        { text: "Advanced", value: "Advanced" },
    ];
    durations: any = [
        { text: "Half Hour", value: 1 },
        { text: "1 Hour", value: 2 },
        { text: "Half Day", value: 3 },
        { text: "Full Day", value: 4 },
    ];
    saveSession(formValues) {
        let session: ISession = {
            id: undefined,
            name: formValues.name,
            duration: +formValues.duration,
            level: formValues.level,
            abstract: formValues.abstract,
            presenter: formValues.presenter,
            voters: []
        }
        this.saveNewSession.emit(session);
    }
    

    cancel() {
        this.cancelAddSession.emit();
        //this.router.navigate(['/events']);
    }

}