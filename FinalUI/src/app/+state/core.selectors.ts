import { createFeatureSelector } from '@ngrx/store';
import { User } from '../models/user.model.ts';
import { Error } from '../models/error.model';
import { Apartament } from '../models/apartament.model';

export const getUsers = createFeatureSelector<User[]>('users');
export const getErrors = createFeatureSelector<Error[]>('errors');
export const getSelecteUser = createFeatureSelector<number | undefined>('selectedUser');
export const getApartamente = createFeatureSelector<Apartament[]>('apartamente')
