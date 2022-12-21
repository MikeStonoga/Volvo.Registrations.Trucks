import { AfterViewInit, Directive, ViewChild } from "@angular/core";
import { TabsComponent } from "src/sdk/components/tabs/tabs.component";
import { IHaveId } from "./i-have-id.model";
import { TabbedService } from "./tabbed.service.model";

@Directive()
export abstract class TabbedComponent<TIEntity extends IHaveId, TService extends TabbedService<TIEntity>> implements AfterViewInit {
    @ViewChild('Tabs') tabsComponent!: TabsComponent;

    constructor(
        protected readonly service: TService,
    ) { }

    ngAfterViewInit(): void {
        this.service.anexarTabsComponent(this.tabsComponent);
    }
}