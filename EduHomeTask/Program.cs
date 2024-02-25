using EduHomeTask.Data;
using EduHomeTask.Model;

EventDao eventDao = new EventDao();
SpeakerDao speakerDao = new SpeakerDao();
List<int> speakerIds = new List<int>();
string opt = "";

while (opt != "0")
{
    Console.Clear();
    Console.WriteLine("***** MENU *****");
    Console.WriteLine("1. Create Speaker");
    Console.WriteLine("2. View Speaker by Id");
    Console.WriteLine("3. View All Speakers");
    Console.WriteLine("4. Delete Speaker");
    Console.WriteLine("5. Update Speaker");
    Console.WriteLine("6. Create Event");
    Console.WriteLine("7. Get Event by Id");
    Console.WriteLine("8. View All Events");
    Console.WriteLine("0. Exit");

    Console.Write("Enter your choice: ");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            AddSpeaker(speakerDao, speakerIds);
            break;
        case "2":
            GetSpeakerById(speakerDao);
            break;
        case "3":
            ViewAllSpeakers(speakerDao);
            break;
        case "4":
            DeleteSpeaker(speakerDao);
            break;
        case "5":
            UpdateSpeaker(speakerDao);
            break;
        case "6":
            CreateEvent(eventDao, speakerIds);
            break;
        case "7":
            ViewAllEvents(eventDao);
            break;
        case "8":
            GetEventById(eventDao);
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
    
 while (opt != "0") 


 static void AddSpeaker(SpeakerDao speakerDao, List<int> speakerIds)

 {
  FullName:
    Console.WriteLine("Enter the FullName:");
    string fullname = Console.ReadLine();
    if (CheckString(fullname))
    {
        Console.WriteLine("Enter valid input");
        goto FullName;
    }
  Position:
    Console.WriteLine("Enter the position:");
    string position = Console.ReadLine();
    if (CheckString(position))
    {
        Console.WriteLine("Enter valid input");
        goto Position;
    }
  Company:
    Console.WriteLine("Enter Company:");
    string company = Console.ReadLine();
    if (CheckString(company))
    {
        Console.WriteLine("Enter valid input");
        goto Company;
    }
  ImageUrl:
    Console.WriteLine("Enter Imageurl:");
    string imageurl = Console.ReadLine();
    if (CheckString(imageurl))
    {
        Console.WriteLine("Enter valid input");
        goto ImageUrl;
    }
    Speaker speaker = new Speaker()
    {
        FullName = fullname,
        Position = position,
        Company = company,
        ImageUrl = imageurl

    };
    speakerDao.Insert(speaker);
    speakerIds.Add(speaker.Id);
 }

 static void GetSpeakerById(SpeakerDao speakerDao)
  {
   Id:
    Console.WriteLine("Enter Id:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("Enter valid input");
        goto Id;

    }
    var data = speakerDao.GetById(id);
    if (data == null) 
        Console.WriteLine("Student not found");
    else
        Console.WriteLine(data);
  }

 static void ViewAllSpeakers(SpeakerDao speakerDao)
 {
    Console.WriteLine("All Students");
    foreach (var item in speakerDao.GetAll())
        Console.WriteLine(item); 
 }

 static void DeleteSpeaker(SpeakerDao speakerDao)
 {
StudentId:
    Console.WriteLine("Enter StudentId:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("Enter valid input");
        goto StudentId;

    }
    var data = speakerDao.GetById(id);
    if (data == null) 
        Console.WriteLine("Student not found");
    else
    {
        speakerDao.Delete(id);
        Console.WriteLine("Student succesfully deleted");
    }
 }
static void UpdateSpeaker(SpeakerDao speakerDao)
{
Id:
    Console.WriteLine("Enter Id:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("Enter valid input");
        goto Id;
    }
    var data = speakerDao.GetById(id);
    if (data == null)
        Console.WriteLine("Not found");
    else
        Console.WriteLine(data);

    FullName:
    Console.WriteLine("Enter new FullName:");
    string fullname = Console.ReadLine();
    if (CheckString(fullname))
    {
        Console.WriteLine("Enter valid input");
        goto FullName;
    }

Position:
    Console.WriteLine("Enter new Position:");
    string position = Console.ReadLine();
    if (CheckString(position))
    {
        Console.WriteLine("Enter valid input");
        goto Position;
    }

Company:
    Console.WriteLine("Enter new Company:");
    string company = Console.ReadLine();
    if (CheckString(company))
    {
        Console.WriteLine("Enter valid input");
        goto Company;
    }

ImageUrl:
    Console.WriteLine("Enter new ImageUrl:");
    string imageurl = Console.ReadLine();
    if (CheckString(imageurl))
    {
        Console.WriteLine("Enter valid input");
        goto ImageUrl;
    }

    Speaker speaker = new Speaker()
    {
        Id = id,
        FullName = fullname,
        Position = position,
        Company = company,
        ImageUrl = imageurl
    };
    speakerDao.Update(speaker);
}


static void CreateEvent(EventDao eventDao, List<int> speakerIds)
{
Name:
    Console.WriteLine("Add Event Name: ");
    string name = Console.ReadLine();

    if (CheckString(name))
    {
        Console.WriteLine("Enter valid input");
        goto Name;
    }

Description:
    Console.WriteLine("Add Description: ");
    string description = Console.ReadLine();

    if (CheckString(description))
    {
        Console.WriteLine("Enter valid input");
        goto Description;
    }

Adress:
    Console.WriteLine("Add Adress: ");
    string adress = Console.ReadLine();
    if (CheckString(adress))
    {
        Console.WriteLine("Enter valid input");
        goto Adress;
    }

StartDate:
    Console.WriteLine("Add StartDate: ");
    string startdateStr = Console.ReadLine();
    DateTime startdate;
    if (!DateTime.TryParse(startdateStr, out startdate))
    {
        Console.WriteLine("Enter valid input");
        goto StartDate;

    }

StartTime:
    Console.WriteLine("Add StartTime: ");
    string starttimeStr = Console.ReadLine();
    TimeSpan starttime;
    if (!TimeSpan.TryParse(starttimeStr, out starttime))
    {
        Console.WriteLine("Enter valid input");
        goto StartTime;

    }

EndTime:
    Console.WriteLine("Add EndTime: ");
    string endtimeStr = Console.ReadLine();
    TimeSpan endtime;
    if (!TimeSpan.TryParse(endtimeStr, out endtime))
    {
        Console.WriteLine("Enter valid input");
        goto EndTime;
    }

    Event event1 = new Event()
    {
        Name = name,
        Description = description,
        Address = adress,
        StartDate = startdate,
        StartTime = starttime,
        EndTime = endtime
    };
    eventDao.Insert(event1, speakerIds);
}

static void GetEventById(EventDao eventDao)
   {
    Id:
    Console.WriteLine("Enter Event Id");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("Enter valid input");
        goto Id;
    }
    var data = eventDao.GetById(id);
    if (data == null)
        Console.WriteLine("Event not found");
    else
        Console.WriteLine(data);
}

 static void ViewAllEvents(EventDao eventDao)
{
    Console.WriteLine("All Events");
    foreach (var item in eventDao.GetAllEvents())
        Console.WriteLine(item);
    
}



static bool CheckString(string input)
{
    return string.IsNullOrWhiteSpace(input);
}