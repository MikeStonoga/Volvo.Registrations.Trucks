import { Directive } from "@angular/core";
import { TabsComponent } from "src/sdk/components/tabs/tabs.component";
import { IHaveId } from "./i-have-id.model";

@Directive()
export abstract class TabbedService<TIEntity extends IHaveId> {
    public tabs = [
        { name: 'List', route: 'list' },
    ];
    
    public tabsComponent!: TabsComponent;
    
    public anexarTabsComponent(tabsComponent: TabsComponent) {
        this.tabsComponent = tabsComponent;
    }

    public goToRegistryTab(registry: TIEntity) {
        this.tabsComponent.changeTab({ name: 'Registry', route: `registry/${registry.id}`, isRemovable: true })
    }
}