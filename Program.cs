using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApplication
{

// _____________CLASS____________
    public class Player
    {
        public string name; 
        public List<Card> hand; 

//player constructor
        public Player(string name)
        {
            this.name = name;
            this.hand = new List<Card>();
        }

//ref and pointer --> points to one object' address instead of duplicating an object
        public Card Draw(ref Deck playersDeck) 
        {
            Card temp = playersDeck.Deal();
            hand.Add(temp);
            return temp;
        }
        public bool Discard(Card discarded)
        {
            foreach (Card item in hand)
            {
                if (discarded.suit == item.suit && discarded.card == item.card )
                {
                    hand.Remove(item);
                    return true;
                }
            }
            return false; //if not in hand
        }
    }
    public class Deck
    {
        public List<Card> cards;
// card value converter
        public string CardConverter(int card_num)
        {
            if (card_num == 1)
            {
                return "A";
            }
            if (card_num < 11 || card_num > 1)
            {
                return "" + card_num; //makes int into a string
            }
            if (card_num == 11)
            {
                return "J";
            }
            if (card_num == 12)
            {
                return "Q";
            }
            if (card_num == 13)
            {
                return "K";
            }
            return "error"; //this should never happen!
        }

//default constructor for Deck
        public Deck()
        {
            Restore();
        }
//deal
        public Card Deal()
        {
           Card deal_card = cards[0];
           cards.RemoveAt(0);
           return deal_card;
        }
//reset Deck
        public void Restore()
        {
            cards = new List<Card>(); //initializing cards from line 12
            for (int card_num = 1; card_num < 14; card_num++)
            {
                for (int suit_val = 1; suit_val < 5; suit_val++ )
                {
                    // for (int val = 0; val < 4; val++ )
                    string suit = "";
                    if (suit_val == 1)
                    {
                        suit = "Hearts";
                    }
                    if (suit_val == 2)
                    {
                        suit = "Spades";
                    }
                    if (suit_val == 3)
                    {
                        suit = "Diamonds";
                    }
                    if (suit_val == 4)
                    {
                        suit = "Clubs";
                    }

                    cards.Add(new Card(CardConverter(card_num), suit, card_num)); //calling function 
                }
            }
        }
//shuffle Deck
        public void Shuffle()
        {
            Random shuffle = new Random();  
            int n = cards.Count;  
            while (n > 1) {  
                n--;  
                int k = shuffle.Next(n + 1);  
                Card val = cards[k];  
                cards[k] = cards[n];  
                cards[n] = val;  
            }  

        }
    }
    public class Card
    {
        public string card;
        public string suit;
        public int numval;
//default constructor for Card
        public Card(string card, string suit, int numval)
        {
            this.card = card;
            this.suit = suit;
            this.numval = numval;
        }
    }

    public class Program
    {
// __________________MAIN__________________    
        public static void Main(string[] args) 
        {

            Player me = new Player("Alex");
            Deck deck = new Deck();
            me.Draw(ref deck);
            printStuff(deck.cards);
            printStuff(me.hand);
            me.Draw(ref deck);
            me.Draw(ref deck);
            deck.Shuffle();
            printStuff(deck.cards);
            me.Draw(ref deck);
            printStuff(deck.cards);
            printStuff(me.hand);



        }
        
        public static void printStuff(List<Card> myCards)
        {
            foreach (Card item in myCards)
            {
                Console.WriteLine(item.card + item.suit);
            }
            Console.WriteLine("******************");

        }
    }
}
