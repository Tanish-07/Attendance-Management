import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {

  activeSection = 'home';
  isScrolled = false;

  navigateToSection(sectionId: string) {
    this.activeSection = sectionId;

    const el = document.getElementById(sectionId);
    if (el) {
      const yOffset = -96; // must match scroll-margin-top
      const y =
        el.getBoundingClientRect().top +
        window.pageYOffset +
        yOffset;

      window.scrollTo({
        top: y,
        behavior: 'smooth',
      });
    }
  }

  @HostListener('window:scroll', [])
  onScroll() {
    this.isScrolled = window.scrollY > 10;

    const sections = ['home', 'problem', 'solution', 'features', 'about', 'contact'];
    const scanLine = 96; // just below navbar

    for (const section of sections) {
      const el = document.getElementById(section);
      if (!el) continue;

      const rect = el.getBoundingClientRect();
      if (rect.top <= scanLine && rect.bottom > scanLine) {
        this.activeSection = section;
        break;
      }
    }
  }
}
