import { Directive, ViewContainerRef, TemplateRef, Input } from "@angular/core";
import { UserService } from '../user-management/user.service';

@Directive({
    selector:'[hasRole]'
})
export class HasRoleDirective {

    constructor(
        private templateRef:TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private userService:UserService
    ) {}

    @Input() set hasRole(roleType:any) {

        // *hasRole="'User'"
        console.log('RoleType:'+roleType)
        if(this.userService.hasRole(roleType)) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }

        // NOTE:-
        // Can add the following into the hasRole method e.g. Pluralsight hasClaim example!
        //      *hasRole="'User:True'"
        //      *hasRole="['User', 'Admin']"
    }
}