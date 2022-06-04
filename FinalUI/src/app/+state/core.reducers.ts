import { state } from '@angular/animations';
import { coerceArray } from '@angular/flex-layout';
import { ActionReducerMap, createReducer, MetaReducer, on } from '@ngrx/store';
import * as CoreActions from './core.actions';
import { CoreState, initialState } from './core.state';
const userReducer = createReducer(
  initialState.users,
  on(CoreActions.LoadUsers, (_, { users }) => {
    return users;
  })
);

const errorsReducer = createReducer(
  initialState.errors,
  on(CoreActions.AddError, (state, { error }) => {
    return [...state, error];
  })
);

const selectedUserReducer = createReducer(
  initialState.selectedUser,
  on(CoreActions.SetSelectedUser, (_, { userId }) => userId)
);

const apartamentsReducer = createReducer(
  initialState.apartamente,
  on(CoreActions.LoadApartaments, (_, { apartamente }) => apartamente),
  on(CoreActions.AddApartamentToState, (state, { apartament }) => [
    ...state,
    apartament,
  ]),
  on(CoreActions.DeleteFromApartament, (state, { apartament }) =>
    state.filter((a) => a.iD_Apartament !== apartament.iD_Apartament)
  ),
  on(CoreActions.ApartamentDoNothing, (state, _) => state)
);

export const reducers: ActionReducerMap<CoreState> = {
  users: userReducer,
  errors: errorsReducer,
  selectedUser: selectedUserReducer,
  apartamente: apartamentsReducer,
};

export const metaReducers: MetaReducer<CoreState>[] = [];
