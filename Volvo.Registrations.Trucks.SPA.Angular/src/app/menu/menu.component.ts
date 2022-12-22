import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { PagesService } from '../pages/pages.service';

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
  public get menus(): Menu[] {return this.pagesService.menus; }

  constructor(
    private readonly router: Router,
    private readonly pagesService: PagesService,
  ) { }

  ngOnInit(): void {
  }

  public goToRoute(menu: Menu) {
    this.activeMenu = menu;
    this.router.navigateByUrl(`/${menu.route}`);
    this.selectedMenu.emit(menu);
  }
}
