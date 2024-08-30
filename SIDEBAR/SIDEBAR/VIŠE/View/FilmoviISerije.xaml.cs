using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using SIDEBAR.VIŠE.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SIDEBAR.VIŠE.View
{
    public partial class FilmoviISerije : UserControl
    {
        public FilmoviISerije()
        {
            InitializeComponent();
            var movie = GetMovie();
            if (movie.Count > 0)
                ListViewMovie.ItemsSource = movie;
        }

        private List<Movie> GetMovie()
        {
            return new List<Movie>()
            {
                new Movie("21 Jump Street (2012)", 7.2, "/SLIKE/21.jpg","Phil Lord & Christopher Miller", "A pair of underachieving cops are sent back to a local high school to blend in and bring down a synthetic drug ring.\r\n\r\n", ShowDescription),
                new Movie("Home Alone (1992)", 7.7, "/SLIKE/home alone.jpg","Chris Columbus", "An eight-year-old troublemaker, mistakenly left home alone, must defend his home against a pair of burglars on Christmas Eve.\r\n\r\n", ShowDescription),
                new Movie("Monty Python and the Holy Grail (1975)", 8.2, "/SLIKE/monty.jpg","Terry Gilliam & Terry Jones", "King Arthur and his Knights of the Round Table embark on a surreal, low-budget search for the Holy Grail, encountering many, very silly obstacles.\r\n\r\n", ShowDescription),
                new Movie("DeadPool (2016)", 8.0, "/SLIKE/Deadpool.jpg","Tim Miller", "A wisecracking mercenary gets experimented on and becomes immortal yet hideously scarred, and sets out to track down the man who ruined his looks.\r\n\r\n", ShowDescription),
               new Movie ("Deadpool 2 (2018)", 7.6, "/SLIKE/deadpool2.jpg" , "David Leitch","Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool), brings together a team of fellow mutant rogues to protect a young boy with supernatural abilities from the brutal, time-traveling cyborg, Cable." ,ShowDescription),
                new Movie ("Deadpool & Wolverine 2024", 8.0, "/SLIKE/deadpool3.jpg" , "Shawn Levy","Deadpool is offered a place in the Marvel Cinematic Universe by the Time Variance Authority, but instead recruits a variant of Wolverine to save his universe from extinction." ,ShowDescription),
               
                new Movie("The Naked Gun: From the Files of Police Squad! (1988)", 7.6, "/SLIKE/naked gun.jpg","David Zucker", "Incompetent police Detective Frank Drebin must foil an attempt to assassinate Queen Elizabeth II.\r\n\r\n", ShowDescription),
                new Movie("Tropic Thunder (2008)", 7.1, "/SLIKE/tropicthund.jpg","Ben Stiller", "Through a series of freak occurrences, a group of actors shooting a big-budget war movie are forced to become the soldiers they are portraying.\r\n\r\n", ShowDescription),
                new Movie("Avengers: Endgame (2019)", 8.4,"/SLIKE/avengers.jpg", "Anthony Russo &Joe Russo", "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.\r\n\r\n", ShowDescription),
                new Movie("Joker (2019)", 8.4, "/SLIKE/joker.jpg", "Todd Phillips","Arthur Fleck, a party clown and a failed stand-up comedian, leads an impoverished life with his ailing mother. However, when society shuns him and brands him as a freak, he decides to embrace the life of crime and chaos in Gotham City", ShowDescription),
                new Movie("Spider-Man: Far From Home (2019)",7.4, "/SLIKE/spider2.jpg","Jon Watts", "Peter Parker and his friends go on a summer trip to Europe. However, they will hardly be able to rest - Peter will have to agree to help Nick Fury uncover the mystery of creatures that cause natural disasters and destruction throughout the continent.\r\n\r\n",ShowDescription),
                new Movie("Once Upon a Time in Hollywood (2019)", 7.6,"/SLIKE/once.jpg","Quentin Tarantino", "As Hollywood's Golden Age is winding down during the summer of 1969, television actor Rick Dalton and his stunt double Cliff Booth endeavor to achieve lasting success in Hollywood while meeting several colorful characters along the way.\r\n\r\n",ShowDescription),
                new Movie ("Star Wars: Episode III - Revenge of the Sith (2005)", 9.8,"/SLIKE/best.jpg","George Lucas","Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan pursues a new threat, Anakin acts as a double agent between the Jedi Council and Palpatine and is lured into a sinister plan to rule the galaxy.\r\n\r\n",ShowDescription),
                new Movie ("Dune: Part One (2021)", 8.0, "/SLIKE/dune.jpg","Denis Villeneuve","A noble family becomes embroiled in a war for control over the galaxy's most valuable asset while its heir becomes troubled by visions of a dark future.\r\n\r\n", ShowDescription),
                new Movie ("Dune: Part Two (2024)",8.5, "/SLIKE/dune2.jpg","Denis Villeneuve","Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family.\r\n\r\n" ,ShowDescription),
                new Movie ("Mulan (2020)",5.8,"/SLIKE/mulan.jpg","Niki Caro","To keep her ailing father from serving in the Imperial Army, a fearless young woman disguises herself as a man and battles northern invaders in China.\r\n\r\n",ShowDescription),
                new Movie ("Godzilla vs. Kong (2021)",6.3,"/SLIKE/vs.jpg","Adam Wingard","The epic next chapter in the cinematic Monsterverse pits two of the greatest icons in motion picture history against each other--the fearsome Godzilla and the mighty Kong--with humanity caught in the balance.\r\n\r\n",ShowDescription),
                new Movie ("Oppenheimer 2023", 8.3,"/SLIKE/death.jpg","Christopher Nolan","The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.\r\n\r\n", ShowDescription),
                
                new Movie("Introducing... Janet (1983)", 3.4, "/SLIKE/face.jpg","Glen Salzman & Rebecca Yates", "This film was shot in Canada and released there as, \"Introducing...Janet.\" Janet is an overweight girl who has a knack for making the other children in school laugh...by making fun of her own weight. She visits the local comedy club, where she finds Tony Moroni, a struggling comedian whose jokes often fail. Together, Tony helps Janet build self-esteem and she helps him with his material.", ShowDescription),
                new Movie ("Elevator Game (2023)", 4.2, "/SLIKE/elevator.jpg" , "Rebekah McKendry","Supernatural horror, based on the eponymous online phenomenon, a ritual conducted in an elevator, in which players attempt to travel to another dimension using a set of rules that can be found online.\r\n\r\n" ,ShowDescription),
                new Movie ("The Beekeeper (2024)", 6.4, "/SLIKE/bee.jpg" , "David Ayer","One man's brutal campaign for vengeance takes on national stakes after he is revealed to be a former operative of a powerful and clandestine organization known as \"Beekeepers\"." ,ShowDescription),
                new Movie ("Mean Girls (2004)", 7.1, "/SLIKE/meangirls.jpg" , "Mark Waters","Cady Heron is a hit with The Plastics, the A-list girl clique at her new school, until she makes the mistake of falling for Aaron Samuels, the ex-boyfriend of alpha Plastic Regina George." ,ShowDescription),
                new Movie ("US (2019)", 6.8, "/SLIKE/us.jpg" , "Jordan Peele","A family's serene beach vacation turns to chaos when their doppelgängers appear and begin to terrorize them." ,ShowDescription),
                new Movie ("Kingsman: The Secret Service (2014)", 7.7, "/SLIKE/kingsman.jpg" , "Matthew Vaughn","A spy organization recruits an unrefined, but promising street kid into the agency's ultra-competitive training program, just as a global threat emerges from a twisted tech genius." ,ShowDescription),
                new Movie ("Kingsman: The Golden Circle (2017)", 6.7, "/SLIKE/kingsman2.jpg" , "Matthew Vaughn","When their headquarters are destroyed and the world is held hostage, the Kingsman's journey leads them to the discovery of an allied spy organization in the United States. These two elite secret organizations must band together to defeat a common enemy." ,ShowDescription),
                new Movie ("The King's Man (2022)", 6.3, "/SLIKE/king.jpg" , "Matthew Vaughn","In the early years of the 20th century, the Kingsman agency is formed to stand against a cabal plotting a war to wipe out millions." ,ShowDescription),
                new Movie ("Top Gun (1986)", 6.9, "/SLIKE/topgun.jpg" , "Tony Scott","As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom." ,ShowDescription),
                new Movie ("Top Gun: Maverick (2022)", 8.2, "/SLIKE/topgun2.jpg" , "Joseph Kosinski","The story involves Maverick confronting his past while training a group of younger Top Gun graduates, including the son of his deceased best friend, for a dangerous mission." ,ShowDescription),
                new Movie ("Free Guy (2020)", 7.1, "/SLIKE/free.jpg" , "Shawn Levy","A bank teller discovers that he's actually an NPC inside a brutal, open world video game." ,ShowDescription),
                new Movie ("Janet Planet (2024)", 6.3, "/SLIKE/janet.jpg" , "Annie Baker","In rural Western Massachusetts, 11-year-old Lacy spends the summer of 1991 at home, enthralled by her own imagination and the attention of her mother, Janet. As the months pass, three visitors enter their orbit, all captivated by Janet." ,ShowDescription),
                new Movie ("Alien: Romulus (2024)", 7.4, "/SLIKE/aline.jpg" , "Fede Alvarez","While scavenging the deep ends of a derelict space station, a group of young space colonists come face to face with the most terrifying life form in the universe." ,ShowDescription),
                new Movie ("Twisters (2024)", 6.7, "/SLIKE/twist.jpg" , "Lee Isaac Chung","An update to the 1996 film 'Twister', which centered on a pair of storm chasers who risk their lives in an attempt to test an experimental weather alert system." ,ShowDescription),
                new Movie ("Despicable Me (2010)", 7.6, "/SLIKE/gru.jpg" , "Pierre Coffin & Chris Renaud","Gru, a criminal mastermind, adopts three orphans as pawns to carry out the biggest heist in history. His life takes an unexpected turn when the little girls see the evildoer as their potential father.\r\n\r\n" ,ShowDescription),
                new Movie ("Despicable me 2 (2013)", 7.3, "/SLIKE/gru2.jpg" , "Pierre Coffin & Chris Renaud","When Gru, the world's most super-bad turned super-dad has been recruited by a team of officials to stop lethal muscle and a host of Gru's own, He has to fight back with new gadgetry, cars, and more minion madness." ,ShowDescription),
                new Movie ("Despicable me 3 (2017)", 6.2, "/SLIKE/gru3.jpg" , "Kyle Balda & Pierre Coffin","Gru meets his long-lost charming, cheerful, and more successful twin brother Dru who wants to team up with him for one last criminal heist." ,ShowDescription),
                new Movie ("Despicable Me 4 (2024)", 6.2, "/SLIKE/gru4.jpg" , "Chris Renaud & Patrick Delage","Gru, Lucy, Margo, Edith, and Agnes welcome a new member to the family, Gru Jr., who is intent on tormenting his dad. Gru faces a new nemesis in Maxime Le Mal and his girlfriend Valentina, and the family is forced to go on the run." ,ShowDescription),
                new Movie ("Inside Out (2015)", 8.1, "/SLIKE/inside.jpg" , "Pete Docter & Ronnie Del Carmen","After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school." ,ShowDescription),
                new Movie ("Inside Out 2 (2024)", 7.7, "/SLIKE/inside2.jpg" , "Kelsey Mann","A sequel that features Riley entering puberty and experiencing brand new, more complex emotions as a result. As Riley tries to adapt to her teenage years, her old emotions try to adapt to the possibility of being replaced." ,ShowDescription),
                
                //new Movie ("", 0, "" , "","" ,ShowDescription)
              



            };  
        }
        private void MovieButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedMovie = button?.DataContext as Movie;
            if (selectedMovie != null)
            {
                var movieDescriptionPage = new MovieDescription();
                movieDescriptionPage.SetMovieDetails(selectedMovie);

                // Get the parent window and change the content of the ContentControl
                var parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    parentWindow.MainContent.Content = movieDescriptionPage;
                }
            }
        }
        private void ShowDescription(Movie movie)
        {
            var movieDescriptionPage = new MovieDescription();
            movieDescriptionPage.SetMovieDetails(movie);
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.MainContent.Content = movieDescriptionPage;
            }
        }
    }
}
    