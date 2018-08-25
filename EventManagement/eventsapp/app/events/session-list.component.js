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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var index_1 = require("./shared/index");
var loadsh_service_1 = require("../common/loadsh-service");
var auth_service_1 = require("../user/auth.service");
var SessionListComponent = /** @class */ (function () {
    function SessionListComponent(_, auth, voterService) {
        this._ = _;
        this.auth = auth;
        this.voterService = voterService;
    }
    SessionListComponent.prototype.ngOnChanges = function (changes) {
        if (this.sessions) {
            this.filterSessions(this.filterBy);
            this.sortSessions(this.sortBy);
        }
    };
    SessionListComponent.prototype.toggleVote = function (session) {
        if (this.userHasVoted(session)) {
            this.voterService.deleteVoter(session, this.auth.currentUser.userName);
        }
        else {
            this.voterService.addVoter(session, this.auth.currentUser.userName);
        }
        if (this.sortBy === "votes") {
            this.sortSessions(this.sortBy);
        }
    };
    SessionListComponent.prototype.userHasVoted = function (session) {
        return this.voterService.userHasVoted(session, this.auth.currentUser.userName);
    };
    SessionListComponent.prototype.filterSessions = function (filter) {
        if (filter === 'all') {
            this.visibleSessions = this.sessions.slice(0);
        }
        else {
            this.visibleSessions = this.sessions.filter(function (s) {
                return s.level.toLowerCase() === filter;
            });
        }
    };
    SessionListComponent.prototype.sortSessions = function (sort) {
        if (sort.toLocaleLowerCase() === 'name') {
            this.visibleSessions = this._.sortBy(this.visibleSessions, sort.toLocaleLowerCase());
        }
        else if (sort.toLocaleLowerCase() === 'votes') {
            this.visibleSessions = this.visibleSessions.sort(this.sortByVoteDesc);
        }
    };
    SessionListComponent.prototype.sortByVoteDesc = function (s1, s2) {
        return (s2.voters.length - s1.voters.length);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Array)
    ], SessionListComponent.prototype, "sessions", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], SessionListComponent.prototype, "filterBy", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], SessionListComponent.prototype, "sortBy", void 0);
    SessionListComponent = __decorate([
        core_1.Component({
            selector: 'session-list',
            templateUrl: 'app/events/session-list.component.html'
        }),
        __param(0, core_1.Inject(loadsh_service_1.LODASH_TOKEN)),
        __metadata("design:paramtypes", [Object, auth_service_1.AuthService, index_1.VoterService])
    ], SessionListComponent);
    return SessionListComponent;
}());
exports.SessionListComponent = SessionListComponent;
//# sourceMappingURL=session-list.component.js.map