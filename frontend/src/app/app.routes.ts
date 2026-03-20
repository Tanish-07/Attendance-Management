import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./landing/view/landing')
        .then(m => m.Landing)
  },
  {
    path: 'signup',
    loadComponent: () =>
      import('./auth/signup/signup')
        .then(m => m.Signup)
  },
  {
    path: 'select-role',
    loadComponent: () =>
      import('./auth/role-select/role-select')
        .then(m => m.RoleSelect)
  },
  {
    path: 'dashboard/admin',
    loadComponent: () =>
      import('./dashboard/admin/admin')
        .then(m => m.Admin)
  },
  {
    path: 'dashboard/user',
    loadComponent: () =>
      import('./dashboard/user/user')
        .then(m => m.User)
  },
  {
    path: 'login/role-select',
    loadComponent: () =>
      import('./auth/role-select/role-select')
        .then(m => m.RoleSelect)
  },
  {
    path: 'login/admin',
    loadComponent: () =>
      import('./auth/login-admin/login-admin')
        .then(m => m.LoginAdmin)
  },
  {
    path: 'login/user',
    loadComponent: () =>
      import('./auth/login-user/login-user')
        .then(m => m.LoginUser)
  },



];
