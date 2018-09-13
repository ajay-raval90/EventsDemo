"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var RX_1 = require("rxjs/RX");
var http_1 = require("@angular/http");
var EventService = /** @class */ (function () {
    function EventService(http) {
        this.http = http;
    }
    EventService.prototype.getEvents = function () {
        //let subject = new Subject<IEvent[]>();
        //setTimeout(function () {
        //    subject.next(Events);
        //    subject.complete();
        //}, 10);
        return this.http.get("/api/events/action/getall").map(function (response) {
            return response.json();
        }).catch(this.handleError);
    };
    EventService.prototype.getEvent = function (id) {
        return this.http.get("/api/events/action/getById?Id=" + id).map(function (response) {
            return response.json();
        }).catch(this.handleError);
    };
    EventService.prototype.saveEvent = function (event) {
        //event.id = 0; //Math.ceil(Math.random() * (2000 - 900) + 900);
        //event.sessions = [];
        //Events.push(event);
        return this.http.post("/api/events/action/save", event).map(function (response) {
            return response.json();
        }).catch(this.handleError);
    };
    EventService.prototype.searchSessions = function (searchTerm) {
        var emitter = new core_1.EventEmitter(true);
        var term = searchTerm.toLocaleLowerCase();
        var results = [];
        this.http.get("/api/events/action/SearchSession?searchTerm=" + term).map(function (response) {
            return response.json();
        }).catch(this.handleError).subscribe(function (res) {
            results = res;
            emitter.emit(results);
            console.log("1", results);
        });
        return emitter;
    };
    EventService.prototype.handleError = function (error) {
        return RX_1.Observable.throw(error.statusText);
    };
    EventService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], EventService);
    return EventService;
}());
exports.EventService = EventService;
//# sourceMappingURL=event-service.js.map