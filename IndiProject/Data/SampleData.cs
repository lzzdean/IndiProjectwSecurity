using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using IndiProject.Models;

namespace IndiProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure Lizz (IsAdmin)
            var lizz = await userManager.FindByNameAsync("lzzdean@gmail.com");
            if (lizz == null)
            {
                // create user
                lizz = new ApplicationUser
                {
                    UserName = "lzzdean@gmail.com",
                    Email = "lzzdean@gmail.com"
                };
                await userManager.CreateAsync(lizz, "Google21!");

                // add claims
                await userManager.AddClaimAsync(lizz, new Claim("IsAdmin", "true"));
            }

            // Ensure Kealy (not IsAdmin)
            var kealy = await userManager.FindByNameAsync("krock@gmail.com");
            if (kealy == null)
            {
                // create user
                kealy = new ApplicationUser
                {
                    UserName = "krock@gmail.com",
                    Email = "krock@gmail.com"
                };
                await userManager.CreateAsync(kealy, "Ilovelizz21!");
            }

            var thrice = new Artist { Name = "Thrice" };
            var aDayToRem = new Artist { Name = "A Day to Remember" };
            var mandyMoore = new Artist { Name = "Mandy Moore" };
            var jtim = new Artist { Name = "Justin Timberlake" };
            var prince = new Artist { Name = "Prince" };
            var manO = new Artist { Name = "Manchester Orchestra" };
            var brandNew = new Artist { Name = "Brand New" };
            var sugar = new Artist { Name = "Sugarcult" };
            var dr = new Artist { Name = "Dr.Dre" };
            var killers = new Artist { Name = "The Killers" };
            var blink = new Artist { Name = "Blink-182" };

            if (!context.Artists.Any())
            {
                context.Artists.AddRange(thrice, aDayToRem, mandyMoore, jtim, prince, manO, brandNew, sugar, dr, killers, blink);
                context.SaveChanges();
            }

            var hotFuss = new Album { Name = "Hot Fuss", Artist = killers, ApplicationUser = lizz };
            var chronic = new Album { Name = "The Chronic", Artist = dr, ApplicationUser = kealy };
            var twoThousand = new Album { Name = "2001", Artist = dr, ApplicationUser = kealy };
            var hope = new Album { Name = "Hope", Artist = manO, ApplicationUser = lizz };
            var cope = new Album { Name = "Cope", Artist = manO, ApplicationUser = lizz };
            var daisy = new Album { Name = "Daisy", Artist = brandNew, ApplicationUser = lizz };
            var signO = new Album { Name = "Sign '0' The Times", Artist = prince, ApplicationUser = lizz };
            var deja = new Album { Name = "Deja Entendu", Artist = brandNew, ApplicationUser = kealy };
            var everywhere = new Album { Name = "To be everywhere is to be Nowhere", Artist = thrice, ApplicationUser = kealy };
            var major = new Album { Name = "Major/Minor", Artist = thrice, ApplicationUser = kealy };
            var homesick = new Album { Name = "Homesick", Artist = aDayToRem, ApplicationUser = lizz };
            var old = new Album { Name = "Old Record", Artist = aDayToRem, ApplicationUser = kealy };
            var palm = new Album { Name = "Palm Trees and Power Lines", Artist = sugar, ApplicationUser = lizz };
            var future = new Album { Name = "FutureSex/LoveSounds ", Artist = jtim, ApplicationUser = lizz };
            var twenty = new Album { Name = "The 20/20 Experience", Artist = jtim, ApplicationUser = lizz };
            var simple = new Album { Name = "Simple Math", Artist = manO, ApplicationUser = kealy };
            var wild = new Album { Name = "Wild Hope", Artist = mandyMoore, ApplicationUser = lizz };
            var coverage = new Album { Name = "Coverage", Artist = mandyMoore, ApplicationUser = kealy };
            var common = new Album { Name = "Common Courtsey", Artist = aDayToRem, ApplicationUser = lizz };


            if (!context.Albums.Any())
            {
                context.Albums.AddRange(hotFuss, chronic, twoThousand, hope, cope, daisy, signO, deja, everywhere, major, homesick, old, palm, future, twenty, simple, wild, coverage, common);
                context.SaveChanges();
            }

            //The Killers: Hot Fuss
            var jenny = new Track { Name = "Jenny Was a Friend of Mine", Album = hotFuss, Length = "4:05" };
            var bright = new Track { Name = "Mr. Brightside", Album = hotFuss, Length = "3:45" };
            var smile = new Track { Name = "Smile Like You Mean it", Album = hotFuss, Length = "3:54" };
            var somebody = new Track { Name = "Somebody Told Me", Album = hotFuss, Length = "3:17" };
            var all = new Track { Name = "All these things that I've done", Album = hotFuss, Length = "5:02" };
            var andy = new Track { Name = "Andy, You're a Star", Album = hotFuss, Length = "3:14" };
            var on = new Track { Name = "On Top", Album = hotFuss, Length = "4:18" };
            var change = new Track { Name = "Change Your Mind", Album = hotFuss, Length = "3:11" };
            var believe = new Track { Name = "Believe Me Natalie", Album = hotFuss, Length = "5:05" };
            var midnight = new Track { Name = "Midnight Show", Album = hotFuss, Length = "4:02" };
            var everything = new Track { Name = "Everything Will Be Alright", Album = hotFuss, Length = "5:45" };

            //Mandy Moore: Wild Hope
            var extra = new Track { Name = "Extraordinary", Album = wild, Length = "2:45" };
            var good = new Track { Name = "All Good Things", Album = wild, Length = "2:53" };
            var slummin = new Track { Name = "Slummin' in Paradise", Album = wild, Length = "4:12" };
            var most = new Track { Name = "Most of Me", Album = wild, Length = "4:47" };
            var few = new Track { Name = "Few Days Down", Album = wild, Length = "3:23" };
            var cant = new Track { Name = "Can't you just Adore Her?", Album = wild, Length = "3:55" };
            var look = new Track { Name = "Looking Forward to Looking Back", Album = wild, Length = "3:23" };
            var hoope = new Track { Name = "Wild Hope", Album = wild, Length = "2:59" };
            var nothing = new Track { Name = "Nothing That You Are", Album = wild, Length = "4:28" };
            var latest = new Track { Name = "Latest Mistake", Album = wild, Length = "4:08" };
            var ladies = new Track { Name = "Ladies Choice", Album = wild, Length = "4:56" };
            var garden = new Track { Name = "Gardenia", Album = wild, Length = "4:27" };

            //Manchester Orchestra: Simple Math 
            var deer = new Track { Name = "Deer", Album = simple, Length = "3:18" };
            var mighty = new Track { Name = "Mighty", Album = simple, Length = "3:36" };
            var pensacola = new Track { Name = "Pensacola", Album = simple, Length = "3:36" };
            var fool = new Track { Name = "April Fool", Album = simple, Length = "4:21" };
            var pale = new Track { Name = "Pale Black Eye", Album = simple, Length = "4:17" };
            var virgin = new Track { Name = "Virgin", Album = simple, Length = "4:34" };
            var math = new Track { Name = "Simple Math", Album = simple, Length = "5:05" };
            var leave = new Track { Name = "Leave it Alone", Album = simple, Length = "4:06" };
            var apprehension = new Track { Name = "Apprehension", Album = simple, Length = "4:34" };
            var leaky = new Track { Name = "Leaky Breaks", Album = simple, Length = "7:14" };

            //Justin Timberlake: The 20/20 Expierence:
            var pusher = new Track { Name = "Pusher Love Girl", Album = twenty, Length = "8.02" };
            var suit = new Track { Name = "Suit & Tie", Album = twenty, Length = "5.26" };
            var dont = new Track { Name = "Don't Hold the Wall", Album = twenty, Length = "7.10" };
            var strawberry = new Track { Name = "Strawberry Bubblegum", Album = twenty, Length = "7:59" };
            var tunnel = new Track { Name = "Tunnel Vision", Album = twenty, Length = "6:46" };
            var spaceship = new Track { Name = "Spaceship Coupe", Album = twenty, Length = "7:17" };
            var that = new Track { Name = "That Girl", Album = twenty, Length = "7:59" };
            var let = new Track { Name = "Let the Groove Get In", Album = twenty, Length = "6:46" };
            var mirrors = new Track { Name = "Mirrors", Album = twenty, Length = "8:05" };
            var blue = new Track { Name = "Blue Ocean Floor", Album = twenty, Length = "7:19" };

            //Justin Timberlake: FutureSex/LoveSounds 
            var love = new Track { Name = "FutureSex/LoveSound", Album = future, Length = "4:01" };
            var sexyback = new Track { Name = "SexyBack", Album = future, Length = "4:02" };
            var sexy = new Track { Name = "Sexy Ladies/Let Me Talk to You", Album = future, Length = "5:32" };
            var my = new Track { Name = "My Love", Album = future, Length = "4:36" };
            var stoned = new Track { Name = "LoveStoned/I Think She Knows", Album = future, Length = "7:24" };
            var what = new Track { Name = "What Goes Around..../...Comes Around", Album = future, Length = "7:24" };
            var chop = new Track { Name = "Chop Me Up", Album = future, Length = "5:04" };
            var damn = new Track { Name = "Damn Girl", Album = future, Length = "5:12" };
            var summer = new Track { Name = "Summer Love/Set the Mood", Album = future, Length = "6:24" };
            var until = new Track { Name = "Until the End of Time", Album = future, Length = "5:22" };
            var losing = new Track { Name = "Losing My Way", Album = future, Length = "5:22" };
            var another = new Track { Name = "(Another Song) All Over Again", Album = future, Length = "5:45" };

            //Sugarcult: Palm Trees and Power Lines
            var shes = new Track { Name = "She's the Blade", Album = palm, Length = "2:59" };
            var crying = new Track { Name = "Crying", Album = palm, Length = "3:29" };
            var memory = new Track { Name = "Memory", Album = palm, Length = "3:46" };
            var worst = new Track { Name = "Worst Decemeber", Album = palm, Length = "3:37" };
            var back = new Track { Name = "Back to California", Album = palm, Length = "4:07" };
            var destination = new Track { Name = "Destination Anywhere", Album = palm, Length = "3:51" };
            var champagne = new Track { Name = "Chapagne", Album = palm, Length = "2:56" };
            var say = new Track { Name = "What you Say", Album = palm, Length = "2:39" };
            var over = new Track { Name = "Over", Album = palm, Length = "3:29" };
            var head = new Track { Name = "Head Up", Album = palm, Length = "3:56" };
            var counting = new Track { Name = "Counting Stars", Album = palm, Length = "3:38" };
            var sign = new Track { Name = "Sign off", Album = palm, Length = "2:13" };
            var blackout = new Track { Name = "Blackout", Album = palm, Length = "3:10" };

            //A Day To Remember: Old Record 
            var intro = new Track { Name = "Intro", Album = old, Length = "0:42" };
            var heartless = new Track { Name = "Heartless", Album = old, Length = "2:46" };
            var your = new Track { Name = "Your Way With Words is through Silence", Album = old, Length = "3:54" };
            var second = new Track { Name = "A Second Glance", Album = old, Length = "2:58" };
            var casa = new Track { Name = "Casablanca Sucked Anyways", Album = old, Length = "2:57" };
            var should = new Track { Name = "You Should have Killed Me When You Had the Chance", Album = old, Length = "3:34" };
            var looks = new Track { Name = "If Looks Could Kill", Album = old, Length = "3:18" };
            var had = new Track { Name = "You had me at hello", Album = old, Length = "4:29" };
            var nineteen = new Track { Name = "1958", Album = old, Length = "4:29" };
            var sound = new Track { Name = "Sound the Alarm", Album = old, Length = "1:29" };

            //A Day To Remember: Homesick
            var downfall = new Track { Name = "The Downfall of Us All", Album = homesick, Length = "3:36" };
            var life = new Track { Name = "My Life For Hire", Album = homesick, Length = "3:33" };
            var wax = new Track { Name = "I'm Made of Wax, Larry, What Are You Made Of?", Album = homesick, Length = "3:00" };
            var nj = new Track { Name = "NJ Legion Iced Tea", Album = homesick, Length = "3:31" };
            var highway = new Track { Name = "Mr.Highway's Thinking About the End", Album = homesick, Length = "4:17" };
            var faith = new Track { Name = "Have Faith in Me", Album = homesick, Length = "3:08" };
            var welcome = new Track { Name = "Welcome to the Family", Album = homesick, Length = "3:00" };
            var home = new Track { Name = "Homesick", Album = homesick, Length = "3:56" };
            var hold = new Track { Name = "Holdin' it Down for the Underground", Album = homesick, Length = "3:23" };
            var already = new Track { Name = "You Already Know What You Are", Album = homesick, Length = "1:27" };
            var weekend = new Track { Name = "Another Song about the Weekend", Album = homesick, Length = "3:45" };
            var means = new Track { Name = "If it Means a lot to You", Album = homesick, Length = "4:03" };

            //Thrice: Major/Minor 
            var yellow = new Track { Name = "Yellow Belly", Album = coverage, Length = "4:08" };
            var promises = new Track { Name = "Promises", Album = coverage, Length = "5:01" };
            var blinded = new Track { Name = "Blinded", Album = coverage, Length = "3:38" };
            var cataracts = new Track { Name = "Cataracts", Album = coverage, Length = "3:08" };
            var call = new Track { Name = "Call It in the Air", Album = coverage, Length = "4:49" };
            var treading = new Track { Name = "Treading Paper", Album = coverage, Length = "3:43" };
            var blur = new Track { Name = "Blur", Album = coverage, Length = "2:59" };
            var words = new Track { Name = "Words in the Water", Album = coverage, Length = "3:31" };
            var listen = new Track { Name = "Listen Through Me", Album = coverage, Length = "4:26" };
            var anthology = new Track { Name = "Anthology", Album = coverage, Length = "3:21" };
            var disarmed = new Track { Name = "Disarmed", Album = coverage, Length = "3:29" };

            //Brand New: Deja Entendu
            var tautou = new Track { Name = "Tautou", Album = deja, Length = "1:42" };
            var sic = new Track { Name = "Sic Transit Gloria...Glory Fades", Album = deja, Length = "3:06" };
            var will = new Track { Name = "I Will Play my Game Beneath the Spin Light", Album = deja, Length = "3:57" };
            var tommy = new Track { Name = "Okay I Believe You, But My Tommy Gun Don't", Album = deja, Length = "5:35" };
            var quiet = new Track { Name = "The Quiet Things That No One Ever Knows", Album = deja, Length = "4:01" };
            var boy = new Track { Name = "The Boy Who Blocked His Own Shot", Album = deja, Length = "4:39" };
            var jaws = new Track { Name = "Jaws Theme Swimming", Album = deja, Length = "4:34" };
            var me = new Track { Name = "Me vs. Maradona vs. Elvis", Album = deja, Length = "5:19" };
            var guernica = new Track { Name = "Guernica", Album = deja, Length = "3:23" };
            var attention = new Track { Name = "Good To Know That If I Ever Need Attention All I Have To Do is Die", Album = deja, Length = "7:00" };
            var play = new Track { Name = "Play Crack the Sky", Album = deja, Length = "5:27" };

            //Prince: Sign o' The Times
            var times = new Track { Name = "Sign o' the Times", Album = signO, Length = "4:57" };
            var sunshine = new Track { Name = "Play in the Sunshine", Album = signO, Length = "5:05" };
            var housequake = new Track { Name = "Housequake", Album = signO, Length = "4:42" };
            var ballad = new Track { Name = "The Ballad of Dorothy Parker", Album = signO, Length = "4:01" };
            var it = new Track { Name = "It", Album = signO, Length = "5:09" };
            var starfish = new Track { Name = "Starfish and Coffee", Album = signO, Length = "2:50" };
            var slow = new Track { Name = "Slow Love", Album = signO, Length = "4:22" };
            var hot = new Track { Name = "Hot Thing", Album = signO, Length = "5:39" };
            var forever = new Track { Name = "Forever in My Life", Album = signO, Length = "3:30" };
            var u = new Track { Name = "U Got the Look", Album = signO, Length = "3:47" };
            var girlfriend = new Track { Name = "If I Was Your Girlfriend", Album = signO, Length = "5:01" };
            var strange = new Track { Name = "Strange Relationship", Album = signO, Length = "4:01" };
            var place = new Track { Name = "I Could Never Take The Place of Your Man", Album = signO, Length = "6:29" };
            var cross = new Track { Name = "The Cross", Album = signO, Length = "4:48" };
            var night = new Track { Name = "It's Gonna be a beautiful night", Album = signO, Length = "9:01" };
            var adore = new Track { Name = "Adore", Album = signO, Length = "6:30" };

            //Brand New: Daisy
            var vices = new Track { Name = "Vices", Album = daisy, Length = "3:25" };
            var bed = new Track { Name = "Bed", Album = daisy, Length = "3:10" };
            var bottom = new Track { Name = "At the Bottom", Album = daisy, Length = "4:04" };
            var stole = new Track { Name = "You Stole", Album = daisy, Length = "6:00" };
            var gone = new Track { Name = "Be Gone", Album = daisy, Length = "1:31" };
            var sink = new Track { Name = "Sink", Album = daisy, Length = "3:20" };
            var bride = new Track { Name = "Bought a Bride", Album = daisy, Length = "3:07" };
            var flower = new Track { Name = "Daisy", Album = daisy, Length = "3:06" };
            var jar = new Track { Name = "In a Jar", Album = daisy, Length = "3:06" };
            var noro = new Track { Name = "Noro", Album = daisy, Length = "6:27" };


            //Manchester Orchestra: Cope 
            var top = new Track { Name = "Top Notch", Album = cope, Length = "3:21" };
            var choose = new Track { Name = "Choose You", Album = cope, Length = "3:14" };
            var girl = new Track { Name = "Girl Harbor", Album = cope, Length = "3:22" };
            var the = new Track { Name = "The Mansion", Album = cope, Length = "3:20" };
            var ocean = new Track { Name = "The Ocean", Album = cope, Length = "3:19" };
            var every = new Track { Name = "Every Stone", Album = cope, Length = "3:38" };
            var wan = new Track { Name = "All that I Really Wanted", Album = cope, Length = "3:02" };
            var trees = new Track { Name = "Trees", Album = cope, Length = "3:09" };
            var indent = new Track { Name = "Indentions", Album = cope, Length = "3:49" };
            var see = new Track { Name = "See It Again", Album = cope, Length = "4:02" };
            var coope = new Track { Name = "Cope", Album = cope, Length = "3:48" };

            //Manchester Orchestra: Hope
            var notch = new Track { Name = "Top Notch", Album = hope, Length = "3:57" };
            var you = new Track { Name = "Choose You", Album = hope, Length = "4:07" };
            var harbor = new Track { Name = "Girl Harbor", Album = hope, Length = "3:55" };
            var mansion = new Track { Name = "The Mansion", Album = hope, Length = "3:22" };
            var water = new Track { Name = "The Ocean", Album = hope, Length = "4:22" };
            var stone = new Track { Name = "Every Stone", Album = hope, Length = "4:40" };
            var really = new Track { Name = "All that I really Wanted", Album = hope, Length = "3:37" };
            var plant = new Track { Name = "Trees", Album = hope, Length = "3:11" };
            var dent = new Track { Name = "Indentions", Album = hope, Length = "3:56" };
            var again = new Track { Name = "See It Again", Album = hope, Length = "2:56" };
            var cooope = new Track { Name = "Cope", Album = hope, Length = "3:05" };

            //Dr.Dre: 2001
            var lolo = new Track { Name = "Lolo", Album = twoThousand, Length = "0:40" };
            var watcher = new Track { Name = "The Watcher", Album = twoThousand, Length = "3:26" };
            var fuck = new Track { Name = "Fuck You", Album = twoThousand, Length = "3:25" };
            var still = new Track { Name = "Still D.R.E", Album = twoThousand, Length = "4:30" };
            var big = new Track { Name = "Big Ego's", Album = twoThousand, Length = "3:57" };
            var explosive = new Track { Name = "Xxplosive", Album = twoThousand, Length = "3:35" };
            var difference = new Track { Name = "What's the Difference", Album = twoThousand, Length = "4:04" };
            var bar = new Track { Name = "Bar One", Album = twoThousand, Length = "0:51" };
            var light = new Track { Name = "Light Speed", Album = twoThousand, Length = "2:40" };
            var forgot = new Track { Name = "Forgot about Dre", Album = twoThousand, Length = "3:42" };
            var next = new Track { Name = "The Next Episode", Album = twoThousand, Length = "2:41" };
            var lets = new Track { Name = "Lets Get High", Album = twoThousand, Length = "2:27" };
            var bitch = new Track { Name = "Bitch Niggaz", Album = twoThousand, Length = "4:13" };
            var car = new Track { Name = "The Car Bomb", Album = twoThousand, Length = "1:00" };
            var murder = new Track { Name = "Murder Ink", Album = twoThousand, Length = "2:28" };
            var education = new Track { Name = "Ed-Ucation", Album = twoThousand, Length = "1:32" };
            var la = new Track { Name = "Some L.A. Niggaz", Album = twoThousand, Length = "4:25" };
            var pause = new Track { Name = "Pause 4 Porno", Album = twoThousand, Length = "1:32" };
            var housewife = new Track { Name = "Housewife", Album = twoThousand, Length = "4:02" };
            var ackrite = new Track { Name = "Ackrite", Album = twoThousand, Length = "3:39" };
            var bang = new Track { Name = "Bang Bang", Album = twoThousand, Length = "3:42" };
            var message = new Track { Name = "The Message", Album = twoThousand, Length = "5:30" };


            ////Dr. Dre: The Chornic
            var chronice = new Track { Name = "The Chronic", Album = chronic, Length = "1:57" };
            var dreDay = new Track { Name = "Fuck wit Dre Day(And Everybody's Celebratin')", Album = chronic, Length = "4:52" };
            var ride = new Track { Name = "Let me Ride", Album = chronic, Length = "4:21" };
            var took = new Track { Name = "The Day the Niggaz Took Over", Album = chronic, Length = "4:33" };
            var g = new Track { Name = "Nuthing but a 'G' Thang", Album = chronic, Length = "3:58" };
            var deez = new Track { Name = "Deeez Nuuuts", Album = chronic, Length = "5:06" };
            var ghetto = new Track { Name = "'Lil'Ghetto Boy", Album = chronic, Length = "5:27" };
            var gun = new Track { Name = "A Nigga Witta Gun", Album = chronic, Length = "3:52" };
            var rat = new Track { Name = "Rat-Tat-Tat-Tat", Album = chronic, Length = "3:48" };
            var sac = new Track { Name = "The $20 Sack Pyramid", Album = chronic, Length = "2:58" };
            var lyrical = new Track { Name = "Lyrical Gangbang", Album = chronic, Length = "4:04" };
            var high = new Track { Name = "High Powered", Album = chronic, Length = "2:44" };
            var doctors = new Track { Name = "The Doctor's Offic", Album = chronic, Length = "1:04" };
            var stranded = new Track { Name = "Stranded on Death Row", Album = chronic, Length = "4:47" };
            var roach = new Track { Name = "The Roach", Album = chronic, Length = "4:36" };
            var aint = new Track { Name = "Bitches Aint Shit", Album = chronic, Length = "4:48" };


            //Thrice: To Be Everywhere is To be Nowhere
            var hurricane = new Track { Name = "Hurricane", Album = everywhere, Length = "4:44" };
            var blood = new Track { Name = "Blood On the Sand", Album = everywhere, Length = "2:50" };
            var window = new Track { Name = "The Window", Album = everywhere, Length = "3:34" };
            var wake = new Track { Name = "Wake Up", Album = everywhere, Length = "4:07" };
            var defeat = new Track { Name = "The Long Defeat", Album = everywhere, Length = "4:11" };
            var seneca = new Track { Name = "Seneca", Album = everywhere, Length = "1:00" };
            var black = new Track { Name = "Black Honey", Album = everywhere, Length = "3:59" };
            var stay = new Track { Name = "Stay With Me", Album = everywhere, Length = "4:00" };
            var death = new Track { Name = "Death from Above", Album = everywhere, Length = "3:37" };
            var whistleblower = new Track { Name = "Whistleblower", Album = everywhere, Length = "3:26" };
            var salt = new Track { Name = "Salt and Shadow", Album = everywhere, Length = "6:08" };

            //A Day To Remember: Common Courtesy:
            var city = new Track { Name = "City of Ocala", Album = common, Length = "3:29" };
            var right = new Track { Name = "Right Back at it Again", Album = common, Length = "3:20" };
            var sometimes = new Track { Name = "Sometimes You're the Hammer, Sometimes You're the Nail", Album = common, Length = "4:34" };
            var dead = new Track { Name = "Dead and Buried", Album = common, Length = "3:13" };
            var best = new Track { Name = "Best of Me", Album = common, Length = "3:27" };
            var goone = new Track { Name = "I'm Already Gone", Album = common, Length = "4:04" };
            var violence = new Track { Name = "Violence(Enough is Enough)", Album = common, Length = "4:01" };
            var eleven = new Track { Name = "Life @ 11", Album = common, Length = "3:22" };
            var surrender = new Track { Name = "I Surrender", Album = common, Length = "3:34" };
            var lessons = new Track { Name = "Life Lessons Learned the Hard Way", Album = common, Length = "2:17" };
            var end = new Track { Name = "End of Me", Album = common, Length = "3:58" };
            var doc = new Track { Name = "The Document Speaks for Itself", Album = common, Length = "4:43" };
            var remember = new Track { Name = "I Remember", Album = common, Length = "9:04" };


            if (!context.Tracks.Any())
            {
                context.Tracks.AddRange(city, right, sometimes, dead, best, goone, violence, eleven, surrender, lessons, end, doc, remember, salt, whistleblower, death, stay, black, seneca, defeat, window, wake, blood, hurricane, aint, roach, stranded, doctors, high, lyrical, sac, rat, gun, ghetto, g, deez, took, ride, dreDay, chronice, lolo, watcher, fuck, still, big, explosive, difference, bar, light, forgot, next, lets, bitch, car, murder, education, la, pause, housewife, ackrite, bang, message, top, choose, girl, the, ocean, every, wan, trees, indent, see, coope, notch, you, harbor, mansion, water, stone, really, plant, dent, again, cooope, vices, bed, bottom, stole, gone, sink, bride, flower, jar, noro, adore, night, cross, place, strange, girlfriend, u, forever, hot, slow, starfish, it, ballad, housequake, sunshine, times, play, attention, guernica, me, jaws, boy, quiet, tommy, will, sic, tautou, disarmed, anthology, listen, words, blur, treading, call, cataracts, blinded, promises, yellow, means, weekend, already, hold, home, welcome, faith, highway, nj, wax, life, downfall, sound, nineteen, had, looks, should, casa, second, your, heartless, intro, blackout, sign, counting, head, over, say, champagne, destination, back, worst, memory, crying, shes, another, losing, until, summer, damn, chop, what, stoned, my, sexy, sexyback, love, blue, mirrors, let, that, spaceship, tunnel, strawberry, dont, suit, pusher, leaky, apprehension, leave, math, virgin, pale, fool, pensacola, mighty, deer, garden, ladies, latest, nothing, hoope, look, cant, few, most, slummin, good, extra, everything, midnight, believe, change, on, andy, all, somebody, smile, bright, jenny);
                context.SaveChanges();
            }

        }

    }
}
