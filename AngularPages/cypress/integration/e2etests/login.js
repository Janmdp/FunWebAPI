/// <reference types="cypress" />

describe('user', () => {
    const Email = "test@test.nl";
    const Password = "test123";


    beforeEach(() => {
        cy.visit('localhost:4200/login');
    })
    
    it('works i hope', () => {
        cy.contains('Login');
    })
    
    it('login', () => {
        cy.get('input[name=Email]').type(Email);
        cy.get('input[name=Password]').type(Password);
        cy.get('button[type=submit]').click();
        cy.url().should('include', 'home');
    })
})

