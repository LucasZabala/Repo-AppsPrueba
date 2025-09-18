import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  // 1. Verificar si el usuario está autenticado
  const isAuthenticated = authService.isLoggedIn(); // Método que verifica si hay un token válido
  if (!isAuthenticated) {
    router.navigate(['/login']); // Redirigir a la página de login si no está autenticado
    return false;
  }

  // 2. Verificar el rol del usuario
  const requiredRoles = route.data['roles'] as string[];
  const userRole = authService.getUserRole(); // Método que obtiene el rol del token
  if (requiredRoles && !requiredRoles.includes(userRole)) {
    router.navigate(['/access-denied']); // Redirigir a una página de acceso denegado
    return false;
  }

  return true; // Permitir el acceso si todo es correcto
};
