import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { RegisterDto } from '../../interfaces/auth.dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerDto: RegisterDto = {
    firstName: '',
    lastName: '',
    username: '',
    password: '',
    role: '' // Se asignará desde la ruta
  };
  successMessage: string = '';
  errorMessage: string = '';
  currentRole: string = '';

  constructor(
    private authService: AuthService, 
    private router: Router, 
    private route: ActivatedRoute // Inyectamos ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Lee el rol de los datos de la ruta
    this.route.data.subscribe(data => {
      this.currentRole = data['role'];
      this.registerDto.role = this.currentRole;
    });
  }

  onRegister(): void {
    // El rol ya está asignado, solo se usa para el registro
    this.authService.register(this.registerDto).subscribe({
      next: (response) => {
        this.successMessage = response.message;
        this.errorMessage = '';
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: (error) => {
        this.successMessage = '';
        this.errorMessage = error.message;
      }
    });
  }
}