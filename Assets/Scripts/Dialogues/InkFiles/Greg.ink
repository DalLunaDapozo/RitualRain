INCLUDE globals.ink


{alreadySaidHi == false: -> Hi} 
{game_accepted == true: -> game_in_motion | -> main}
=== Hi ===

Hi... :)

~alreadySaidHi = true

-> main

=== main ===

I want to play hide and seek

You find a place to hide and I will look for you

Try to find a good place

If you do not hide I won't look for you

->Question

= Question

What do you say ?

*[Let's do it]

    Good !
    
    I will start now
        
    ~game_accepted = true
    
    -> END
    
    *[What happens if you find me ?]
    
    Mmmmmmm, I might get upset
    
    -> Question
    
    
     *[Not now]
    
    I undestand 
    
    :(
    
    -> END

=== game_in_motion ===

Go find a place to hide 

-> END

=== alreadyPlayed ===

That was fun

-> END