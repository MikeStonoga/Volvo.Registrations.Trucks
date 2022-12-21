import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

export interface Menu {
  label: string;
  icon: string;
  route: string;
}

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  @Output() selectedMenu: EventEmitter<Menu> = new EventEmitter<Menu>();

  public activeMenu!: Menu;

  public readonly menus: Menu[] = [
    { label: 'Home', icon: 'home', route: 'home' },
    { label: 'Trucks', icon: 'local_shipping', route: 'trucks' },
  ];

  constructor(
    private readonly router: Router,
  ) { }

  ngOnInit(): void {
  }

  public goToRoute(menu: Menu) {
    this.activeMenu = menu;
    this.router.navigateByUrl(`/${menu.route}`);
    this.selectedMenu.emit(menu);
  }
}
