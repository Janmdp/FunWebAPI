/// <reference types="cypress" />

describe('user', () => {
    const Email = "test@test.nl";
    const Password = "test123";


    beforeEach(() => {
        cy.login(Email,Password)
    })
    
    it('works i hope', () => {
        cy.contains('Login');
    })
    
    it('login', () => {
        cy.url().should('include', 'home');
    })
})

