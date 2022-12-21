import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

export interface Tab {
  name: string;
  route: string;
  isRemovable?: boolean;
}


@Component({
  selector: 'my-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss']
})
export class TabsComponent implements OnInit {
  @Input() tabs: Tab[] = [];
  @Output() selected: EventEmitter<Tab> = new EventEmitter<Tab>(); 
  public activeTab?: Tab;

  constructor(
    private readonly router: Router,
    private readonly route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.changeTab(this.tabs[0]);
  }

  public changeTab(tab: Tab) {
    if (!this.tabs.map(t => t.name).includes(tab.name)) {
      tab.isRemovable = true;
      this.tabs.push(tab);
    }

    if (this.activeTab?.name !== tab.name) {
      this.activeTab = tab;
      this.router.navigate([tab.route], { relativeTo: this.route });
      this.selected.emit(tab);
    }
  }

  public removeTab(tab: Tab) {
    const index = this.tabs.findIndex(t => tab.name === t.name);

    if (index === -1)
      return;

    this.tabs.splice(index, 1);
    const previousTab = this.tabs[index - 1];
    this.changeTab(previousTab)
  }


  removeCurrentTab() {
    if (this.activeTab?.isRemovable) {
      this.removeTab(this.activeTab);
    }
  }

}
