import { Component } from '@angular/core';



import { Hero } from '../sections/hero/hero';
import { Problem } from '../sections/problem/problem';
import { Solution } from '../sections/solution/solution';
import { Contact } from '../sections/contact/contact';
import { Navbar } from '../sections/navbar/navbar';
import { Footer } from '../../shared/components/footer/footer';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [
    Navbar,
    Footer,
    Hero,
    Problem,
    Solution,
    // Features,
    // About,
    Contact
  ],
  templateUrl: './landing.html',
  styleUrl: './landing.css',
})
export class Landing {}
