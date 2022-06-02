import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { getSelecteUser, getUsers, SetSelectedUser } from 'src/app/+state';
import { User } from 'src/app/models/user.model.ts';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
})
export class NavigationComponent implements OnInit {
  selectedUser$?: Observable<number | undefined> = undefined;
  users$: Observable<User[]> = of([]);

  constructor(private _store: Store) {}

  ngOnInit(): void {
    this.users$ = this._store.select(getUsers).pipe((users) => users);
    this.selectedUser$ = this._store.select(getSelecteUser).pipe((id) => id);
  }

  handleChange(e) {
    this._store.dispatch(SetSelectedUser({ userId: e.value }));
  }
}
