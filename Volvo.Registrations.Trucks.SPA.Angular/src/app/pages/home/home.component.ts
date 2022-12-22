import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu, MenuComponent } from 'src/app/menu/menu.component';
import { PagesService } from '../pages.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public get pages(): Menu[] {return this.pagesService.menus.filter(e => e.label != "Home"); }
  
  constructor(
    public readonly router: Router,
    private readonly pagesService: PagesService,
  ) { 
  }

  ngOnInit(): void {
  }

  public goToPage(page: Menu) {
    this.router.navigateByUrl(`/${page.route}`);
  }

}
