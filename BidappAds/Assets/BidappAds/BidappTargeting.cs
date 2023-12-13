namespace Bidapp
{
    public static class BidappTargeting
    {
        /**
        * Targeting metadata keys
        */
        public const string Keywords = "keywords";                /** application keywords. A free form set of keywords, separated by ',' e.g: @"sports,cars,bikes" */
        public const string UserInterests = "interests";        /** user's interests param. A free form set of interests, separated by ',' */
        public const string UserAge = "age";                    /** user's age param, e.g: @"25" */
        public const string UserGender = "gender";                /** user's gender param */
        public const string UserBirthday = "birthday";            /** user's birthday param. Value should be in format dd.MM.yyyy, e.g: "01.01.2000" */
        public const string UserOccupation = "occupation";        /** user's occupation param */
        public const string UserRelationship = "relationship";    /** user's relationship param */
        public const string UserLatitude = "latitude";            /** user's current latitude param */
        public const string UserLongitude = "longitude";        /** user's current longitude param */
        /**
         * Targeting metadata values (for pre-defined values)
         */        
        public const string UserGenderMale = "male";        /** User is male */
        public const string UserGenderFemale = "female";    /** User is female */
        
        public const string UserOccupationSchool = "school";            /** User goes to school */
        public const string UserOccupationUniversity = "university";    /** User at university */
        public const string UserOccupationWork = "work";                /** User is working */
        
        public const string UserRelationshipSingle = "single";        /** User is single */
        public const string UserRelationshipEngaged = "engaged";    /** User is engaged */
        public const string UserRelationshipMarried = "married";    /** User is married */
        public const string UserRelationshipDivorced = "divorced";    /** User is divorced */
    };
}
