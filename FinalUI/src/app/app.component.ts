import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { BeginLoadingApartaments, BeginLoadingUser } from './+state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'FinalUI';

  constructor(private _store: Store) {}

  ngOnInit(): void {
    this._store.dispatch(BeginLoadingApartaments());
    this._store.dispatch(BeginLoadingUser());
  }
}
