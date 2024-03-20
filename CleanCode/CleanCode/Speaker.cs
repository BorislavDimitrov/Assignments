using CleanCode.Exceptions;

namespace CleanCode
{
    public class Speaker
    {
        private readonly List<string> Domains = new List<string>{ "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
        private readonly List<string> Employers = new List<string> { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
        private readonly List<string> OldTechnologies = new List<string> { "Cobol", "Punch Cards", "Commodore", "VBScript" };
        private const int RequiredSertificates = 3;

        private string _firstName;
        private string _lastName;
        private string _email;
        private int _experience;
        private string _blogURL;
        private WebBrowser _browser;
        private string _employer;
        private int _registrationFee;

        public string FirstName 
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First Name is required");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last Name is required");
                }
                _lastName = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email is required");
                }
                _email = value;
            }
        }

        public int Experience
        {
            get => _experience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Experience cannot be negative");
                }
                _experience = value;
            }
        }

        public bool HasBlog { get; set; }

        public string BlogURL 
        {
            get => _blogURL;
            set
            {
                if (HasBlog == false)
                {
                    throw new InvalidOperationException("The speaker doesnt have blog");
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Blog cannot be null");
                }
                _blogURL = value;
            }
        }

        public WebBrowser Browser 
        {
            get => _browser;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Browser is required");
                }
                _browser = value;
            }
        }

        public List<string> Certifications { get; set; } = new List<string>();

        public string Employer
        {
            get => _employer;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Employer is required");
                }
                _employer = value;
            }
        }

        public List<Session> Sessions { get; set; } = new List<Session>();

        public int RegistrationFee => _registrationFee;

        /// <summary>
        /// Register a speaker
        /// </summary>
        /// <returns>speakerID</returns>
        public int? Register(IRepository repository)
        {
            ValidateRequired(FirstName, "First Name");
            ValidateRequired(LastName, "Last Name");
            ValidateRequired(Email, "Email");


            if ( ValidateSpeaker() == false)
            {
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            }

            if (Sessions.Count() == 0)
            {
                throw new ArgumentException("Can't register speaker with no sessions to present.");
            }

            bool isSessionApproved = false;

            foreach (var session in Sessions)
            {
                foreach (var tech in OldTechnologies)
                {
                    if (session.Title.Contains(tech) || session.Description.Contains(tech))
                    {
                        session.Approved = false;
                        break;
                    }
                    else
                    {
                        session.Approved = true;
                        isSessionApproved = true;
                    }
                }
            }

            if (isSessionApproved == false)
            {
                throw new NoSessionsApprovedException("No sessions approved.");
            }
                        
            DetermineRegistrationFee();

            int? speakerId = null;

            try
            {
                speakerId = repository.SaveSpeaker(this);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to register speaker");
            }

            return speakerId;
        }  

        private void DetermineRegistrationFee()
        {         
            if (Experience <= 1)
            {
                _registrationFee = 500;
            }
            else if (Experience >= 2 && Experience <= 3)
            {
                _registrationFee = 250;
            }
            else if (Experience >= 4 && Experience <= 5)
            {
                _registrationFee = 100;
            }
            else if (Experience >= 6 && Experience <= 9)
            {
                _registrationFee = 50;
            }
            else
            {
                _registrationFee = 0;
            }
        }

        private bool ValidateSpeaker()
        {
            var isValid = ((Experience > 10 || HasBlog || Certifications.Count() > RequiredSertificates || Employers.Contains(Employer)));

            if (isValid == false)
            {
                string emailDomain = Email.Split('@').Last();

                if (Domains.Contains(emailDomain) && ((Browser.Name == BrowserName.InternetExplorer && Browser.MajorVersion < 9)))
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private  void ValidateRequired( string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{propertyName} is required.");
            }
        }
    }
}
