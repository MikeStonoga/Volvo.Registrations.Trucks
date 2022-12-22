import { Injectable } from '@angular/core';
import { Menu } from '../menu/menu.component';

@Injectable({
  providedIn: 'root'
})
export class PagesService {
  public readonly menus: Menu[] = [
    { label: 'Home', icon: 'home', route: 'home' },
    { label: 'Trucks', icon: 'local_shipping', route: 'trucks' },
  ];
}
