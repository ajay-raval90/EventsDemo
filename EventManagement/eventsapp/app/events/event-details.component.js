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
var event_service_1 = require("./shared/event-service");
var router_1 = require("@angular/router");
var EventDetailsComponent = /** @class */ (function () {
    function EventDetailsComponent(eventService, route) {
        this.eventService = eventService;
        this.route = route;
        this.filterBy = 'all';
        this.sortBy = 'name';
    }
    EventDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.forEach(function (routeParams) {
            _this.eventService.getEvent(+routeParams['id']).subscribe(function (event) {
                console.log(event);
                _this.event = event;
                _this.resetComponent();
            });
        });
    };
    EventDetailsComponent.prototype.addSession = function () {
        this.addMode = true;
    };
    EventDetailsComponent.prototype.resetComponent = function () {
        this.addMode = false;
        this.filterBy = "all";
        this.sortBy = "name";
    };
    EventDetailsComponent.prototype.saveNewSession = function (session) {
        var nextId = Math.max.apply(null, this.event.sessions.map(function (s) { return s.id; }));
        session.id = nextId + 1;
        this.event.sessions.push(session);
        this.eventService.updateEvent(this.event);
        this.addMode = false;
    };
    EventDetailsComponent.prototype.cancelAddSession = function () {
        this.addMode = false;
    };
    EventDetailsComponent = __decorate([
        core_1.Component({
            selector: 'event-detail',
            templateUrl: 'app/events/event-details.component.html',
            styles: [
                ".container {padding-left:20px; padding-right:20px}\n        .event-image {height:100px;}\n        a {cursor:pointer}\n        "
            ]
        }),
        __metadata("design:paramtypes", [event_service_1.EventService, router_1.ActivatedRoute])
    ], EventDetailsComponent);
    return EventDetailsComponent;
}());
exports.EventDetailsComponent = EventDetailsComponent;
//# sourceMappingURL=event-details.component.js.map