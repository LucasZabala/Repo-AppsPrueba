import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { LoginDto } from '../../interfaces/auth.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginDto: LoginDto = {
    username: '',
    password: ''
  };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onLogin(): void {
    this.authService.login(this.loginDto).subscribe({
      next: (response) => {
        // Redirigir según el rol después de un login exitoso
        const userRole = this.authService.getUserRole();
        if (userRole === 'Admin') {
          this.router.navigate(['/administrador']);
        } else if (userRole === 'Employee') {
          this.router.navigate(['/empleado']);
        } else if (userRole === 'Client') {
          this.router.navigate(['/cliente']);
        } else {
          // Si no se encuentra un rol, redirigir a una página por defecto
          this.router.navigate(['/']); 
        }
      },
      error: (error) => {
        this.errorMessage = error.message;
      }
    });
  }
}