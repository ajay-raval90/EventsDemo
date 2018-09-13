import { Injectable, EventEmitter } from '@angular/core';
import { Subject, Observable } from 'rxjs/RX';
import { IEvent } from './index'
import { ISession } from "./event.model";
import { Http, Response } from "@angular/http";

@Injectable()
export class EventService {
    constructor(private http: Http) {
        
    }
    getEvents(): Observable<IEvent[]> {
        
        //let subject = new Subject<IEvent[]>();
        //setTimeout(function () {
        //    subject.next(Events);
        //    subject.complete();
        //}, 10);
        return this.http.get("/api/events/action/getall").map((response: Response) => {
            return <IEvent[]>response.json();
        }).catch(this.handleError);
    }
    getEvent(id: number): Observable<IEvent>{
        return this.http.get("/api/events/action/getById?Id=" + id).map((response: Response) => {
            return <IEvent>response.json();
        }).catch(this.handleError);
    }
    saveEvent(event): Observable<IEvent>{
        //event.id = 0; //Math.ceil(Math.random() * (2000 - 900) + 900);
        //event.sessions = [];
        //Events.push(event);
        return this.http.post("/api/events/action/save",event).map((response: Response) => {
            return <IEvent>response.json();
        }).catch(this.handleError);
        
    }
    
    searchSessions(searchTerm: string) {
        var emitter = new EventEmitter(true);

        
        let term = searchTerm.toLocaleLowerCase();
        var results: ISession[] = [];
        this.http.get("/api/events/action/SearchSession?searchTerm=" + term).map((response: Response) => {
            return <IEvent>response.json();
        }).catch(this.handleError).subscribe((res: ISession[]) => {
            results = res;
            emitter.emit(results);
            console.log("1", results)
            });


        return emitter;   
    }

    handleError(error: Response) {
        return Observable.throw(error.statusText);
    }
}

